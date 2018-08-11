using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpeed : MonoBehaviour 
{
	public float Accelleration;
	public float Decceleration;
	public float TopSpeed;
	public float Speed {get; private set;}
	private bool _collided;
	// Use this for initialization
	void Start () {
		
	}
	
	
	/// <summary>
	/// OnCollisionStay is called once per frame for every collider/rigidbody
	/// that is touching rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionStay(Collision other)
	{
		_collided = true;
	}

	// Update is called once per frame
	void Update () {
		if (_collided)
		{
			Speed = Mathf.Max(0,Speed -  Decceleration*Time.deltaTime);
		}
		else
		{
			Speed = Mathf.Min(TopSpeed, Speed + Accelleration*Time.deltaTime);
		}		
		transform.position += Vector3.right * Speed * Time.deltaTime;
		_collided = false;
	}
}
