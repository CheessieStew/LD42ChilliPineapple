using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour {
	public AudioClip eatingSound;

	private AudioSource source;
	private PlayerScores playerScores;

	// Use this for initialization
	void Awake() {
		source = GetComponent<AudioSource>();
		playerScores = gameObject.GetComponent<PlayerScores>();
		Debug.Assert(playerScores != null, "PlayerScores must be assigned.");
	}

	void OnTriggerEnter(Collider other) {
		{
			if (other.gameObject.CompareTag("Eatable")) {
				var eatable = other.gameObject.GetComponent<Eatable>();
				if (eatable) {
					eatable.GetEaten();
					playerScores.Score += eatable.Value;
				}
				source.PlayOneShot(eatingSound, 1.0f);
			}
		}
	}
}