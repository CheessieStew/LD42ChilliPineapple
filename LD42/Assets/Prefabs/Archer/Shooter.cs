using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public float rotationSpeed = 0.8f;
	public GameObject ArrowPrefab;

	Transform bow;
	Transform target;

	void Start()
	{
		bow = transform.Find("Bow");
		target = GameObject.FindWithTag("Player").transform;

		InvokeRepeating("ShootArrow", 1.5f, 2f);
	}

	void Update()
	{
		bow.localPosition = Vector3.RotateTowards(
			bow.localPosition,
			target.position - transform.position,
			rotationSpeed * Time.deltaTime,
			0f
		);
	}

	private void ShootArrow()
	{
		var arrowGO = Instantiate(
			ArrowPrefab,
			bow.position,
			Quaternion.LookRotation(
				target.position - transform.position,
				Vector3.up
			)
		);
		arrowGO.GetComponent<Arrow>().targetPosition = target.position;
	}
}