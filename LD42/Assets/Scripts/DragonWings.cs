using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWings : MonoBehaviour
{
	public float FlapStrength;
	public float FallingStrBonus;
	public float Cooldown;
	private float _activeCooldown;
	private bool _lock;
	private Rigidbody _rigidbody;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (_activeCooldown <= 0)
		{
			if (Input.GetAxis("Jump") > 0)
			{
				if (_lock == false)
				{
					_lock = true;
					_activeCooldown = Cooldown;

					_rigidbody.AddForce(
						Vector3.up * FlapStrength * Mathf.Pow(
							1 - Mathf.Min(_rigidbody.velocity.y, 0),
							FallingStrBonus
						), ForceMode.Impulse
					);
				}
			}
			else
			{
				_lock = false;
			}
		}
		else
		{
			_activeCooldown -= Time.deltaTime;
		}
	}
}