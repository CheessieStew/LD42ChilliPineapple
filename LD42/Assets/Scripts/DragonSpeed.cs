using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpeed : MonoBehaviour
{
	public float Accelleration;
	public float Decceleration;
	public float TopSpeed;
	public float Speed { get; private set; }
	private float _collided;
	// Use this for initialization
	void Start()
	{

	}

	void OnCollisionStay(Collision other)
	{
		_collided = 0.2f;
	}

	void Update()
	{
		if (_collided > 0)
		{
			Speed = Mathf.Max(0, Speed - Decceleration * Time.deltaTime);
			_collided -= Time.deltaTime;
		}
		else
		{
			Speed = Mathf.Min(TopSpeed, Speed + Accelleration * Time.deltaTime);
		}
		transform.position += Vector3.right * Speed * Time.deltaTime;
	}
}