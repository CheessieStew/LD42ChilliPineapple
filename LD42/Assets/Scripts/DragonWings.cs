using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWings : MonoBehaviour {
	public float FlapStrength;
	public float Cooldown;
	private float _activeCooldown;
	private Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if ( _activeCooldown <= 0)
		{
			if (Input.GetAxis("Jump") > 0)
			{
				_activeCooldown = Cooldown;
 				_rigidbody.AddForce(Vector3.up*FlapStrength, ForceMode.Impulse);
			}
		}
		else
		{
			_activeCooldown -= Time.deltaTime;
		}
	}
}
