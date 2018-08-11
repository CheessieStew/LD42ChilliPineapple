using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arrow : MonoBehaviour
{
	public Vector3 targetPosition;
	public float speed = 10;
	public float arcHeight = 1;

	Vector3 initialPosition;

	void Start()
	{
		initialPosition = transform.position;
	}

	void Update()
	{
		float z0 = initialPosition.z;
		float z1 = targetPosition.z;
		float x0 = initialPosition.x;
		float x1 = targetPosition.x;

		float dist = z1 - z0;
		float nextX = Mathf.MoveTowards(
			transform.position.x,
			x1,
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
		Debug.Log(nextPos);

		transform.rotation = Quaternion.LookRotation(nextPos - transform.position);
		transform.position = nextPos;

		if (nextPos == targetPosition)
		{
			Destroy(gameObject);
		}
	}
}