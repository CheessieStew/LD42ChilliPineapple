using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyDrake {
	public class PlayerHealth : MonoBehaviour {
		public Text healthText;

		public int health = 100;
		public int damage = 1;

		void Start() {
			SetHealthText();
		}

		void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Projectile")) {
				health -= damage;
				SetHealthText();
			}
		}

		void SetHealthText() {
			if (healthText == null) {
				return;
			}
			healthText.text = "Health: " + health.ToString();
		}
	}
}