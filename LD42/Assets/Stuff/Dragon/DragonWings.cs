using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDrake {

	[RequireComponent(typeof(Rigidbody))]
	public class DragonWings : MonoBehaviour {
		public float FlapStrength = 3111;
		public float FallingStrBonus = 0.3f;
		public float Cooldown = 0.03f;

		private float activeCooldown;
		private bool locked;
		private new Rigidbody rigidbody;

		void Start() {
			rigidbody = GetComponent<Rigidbody>();
		}

		void Update() {
			if (activeCooldown <= 0) {
				if (Input.GetAxis("Jump") > 0) {
					if (locked == false) {
						locked = true;
						activeCooldown = Cooldown;

						rigidbody.AddForce(
							Vector3.up * FlapStrength * Mathf.Pow(
								1 - Mathf.Min(rigidbody.velocity.y, 0),
								FallingStrBonus
							), ForceMode.Impulse
						);
					}
				} else {
					locked = false;
				}
			} else {
				activeCooldown -= Time.deltaTime;
			}
		}
	}
}