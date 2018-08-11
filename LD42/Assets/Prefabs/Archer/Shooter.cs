using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public float rotationSpeed = 0.8f;

	Transform bow;
	Transform target;

	void Start()
	{
		bow = transform.Find("Bow");
		target = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		bow.localPosition = Vector3.RotateTowards(
			bow.localPosition,
			target.position - transform.position,
			rotationSpeed * Time.deltaTime,
			0f);
	}
}