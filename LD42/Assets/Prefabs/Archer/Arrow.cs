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
	public float speed = 10;
	public float arcHeight = 1;

	ProjectileState state = ProjectileState.Flying;
	Vector3 initialPosition;
	Vector3 lastPosition;

	new Rigidbody rigidbody;

	void Start() {
		rigidbody = gameObject.GetComponent<Rigidbody>();
		initialPosition = transform.position;
	}

	void Update() {
		switch (state) {
		case ProjectileState.Flying:
			var flightResult = Fly();
			transform.rotation = flightResult.Item1;
			var pos = flightResult.Item2;

			if (pos == targetPosition) {
				state = ProjectileState.StartsFalling;
				lastPosition = transform.position;
			}

			transform.position = pos;
			break;

		case ProjectileState.StartsFalling:
			rigidbody.constraints = RigidbodyConstraints.None;
			rigidbody.velocity = (transform.position - lastPosition) / Time.deltaTime;
			this.enabled = false;
			Destroy(this);
			Destroy(gameObject, 8f);

			break;

		case ProjectileState.Stuck:
			// to ewentualnie jak bedzie smok, zobaczymy czy chcemy żeby się wbijały
			Destroy(gameObject);

			break;

		default:
			throw new UnityException("Switch case unhandled");
		}
	}

	System.Tuple<Quaternion, Vector3> Fly() {
		float z0 = initialPosition.z;
		float z1 = targetPosition.z;

		float dist = z1 - z0;
		float nextX = Mathf.MoveTowards(
			transform.position.x,
			targetPosition.x,
			speed * Time.deltaTime
		);
		float nextZ = Mathf.MoveTowards(
			transform.position.z,
			z1,
			speed * Time.deltaTime
		);

		float baseY = Mathf.Lerp(initialPosition.y, targetPosition.y, (nextZ - z0) / dist);
		float arc = arcHeight * (nextZ - z0) * (nextZ - z1) / (-0.25f * dist * dist);
		var nextPos = new Vector3(nextX, baseY + arc, nextZ);

		return new System.Tuple<Quaternion, Vector3>(
			Quaternion.LookRotation(nextPos - transform.position),
			nextPos
		);
	}
}