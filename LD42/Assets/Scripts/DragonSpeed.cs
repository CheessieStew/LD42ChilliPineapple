﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragonSpeed : MonoBehaviour
{
	public float Accelleration;
	public float Decceleration;
	public float TopSpeed;
	private float _collided;
	private Rigidbody _rigidbody;
	// Use this for initialization
	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void OnCollisionStay(Collision other)
	{
		if (other.contacts.Any(cp =>cp.normal.y > 0))
		_collided = 0.2f;
	}

	void Update()
	{
		if (_collided > 0)
		{
			if (_rigidbody.velocity.x > 0)
			{
				_rigidbody.AddForce(Vector3.right * Decceleration, ForceMode.Acceleration);
			}
			_collided -= Time.deltaTime;
		}
		else if (_rigidbody.velocity.x < TopSpeed)
		{
			_rigidbody.AddForce(Vector3.right * Accelleration, ForceMode.Acceleration);
		}
		
	}
}
