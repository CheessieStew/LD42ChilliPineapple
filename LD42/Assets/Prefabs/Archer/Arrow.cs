using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arrow : MonoBehaviour {
	enum ProjectileState {
		Flying,
		Stuck,
		StartsFalling
	}

	public Vector3 targetPosition;
	public float speedX = 20;

	ProjectileState state = ProjectileState.Flying;
	Vector3 initialPosition;
	Vector3 lastPosition;

	new Rigidbody rigidbody;

	float arcHeight = 1;
	float x0;
	float x1;
	float distX;
	float distZ;
	float speedZ;

	void Start() {
		rigidbody = gameObject.GetComponent<Rigidbody>();
		initialPosition = transform.position;

		arcHeight = Mathf.Sqrt(
			Mathf.Abs(Vector2.Distance(
				new Vector2(initialPosition.x, initialPosition.z),
				new Vector2(targetPosition.x, targetPosition.z)
			) - Mathf.Abs(transform.position.y - transform.position.y))
		);

		x0 = initialPosition.x;
		x1 = targetPosition.x;
		distX = Mathf.Abs(x1 - x0);
		distZ = Mathf.Abs(targetPosition.z - initialPosition.z);
		speedZ = speedX * (distZ / distX);

		Destroy(gameObject, 30f);
	}

	void Update() {
		switch (state) {
		case ProjectileState.Flying:
			var flightResult = Fly();
			transform.rotation = flightResult.Item1;
			var pos = flightResult.Item2;

			if (Vector3.Distance(pos, targetPosition) < 2) {
				state = ProjectileState.StartsFalling;

				if (transform.position == lastPosition) {
					Destroy(this);
				}
				lastPosition = transform.position;
			}

			transform.position = pos;
			break;

		case ProjectileState.StartsFalling:
			rigidbody.constraints = RigidbodyConstraints.None;
			rigidbody.velocity = (transform.position - lastPosition) / Time.deltaTime;
			this.enabled = false;
			Destroy(this);
			Destroy(gameObject, 12f);

			break;

		case ProjectileState.Stuck:
			// to ewentualnie jak bedzie smok, zobaczymy czy chcemy żeby się wbijały
			break;

		default:
			throw new UnityException("Switch case unhandled");
		}
	}

	System.Tuple<Quaternion, Vector3> Fly() {
		float nextX = Mathf.MoveTowards(
			transform.position.x,
			x1,
			speedX * Time.deltaTime
		);
		float nextZ = Mathf.MoveTowards(
			transform.position.z,
			targetPosition.z,
			speedZ * Time.deltaTime
		);

		float baseY = Mathf.Lerp(initialPosition.y, targetPosition.y, (nextX - x0) / distX);
		float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * distX * distX);
		var nextPos = new Vector3(nextX, baseY + arc, nextZ);

		return new System.Tuple<Quaternion, Vector3>(
			Quaternion.LookRotation(nextPos - transform.position),
			nextPos
		);
	}
}