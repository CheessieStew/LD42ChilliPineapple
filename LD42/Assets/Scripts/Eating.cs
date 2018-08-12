using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
	public AudioClip eatingSound;

	private Eatable justEaten;
	private AudioSource source;
    private PlayerScores playerScores;

	// Use this for initialization
	void Start()
	{
		source = GetComponent<AudioSource>();
        playerScores = gameObject.AddComponent<PlayerScores>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Eatable"))
		{
            playerScores.UpdateCurrentScore();

			justEaten = other.gameObject.GetComponent<Eatable>();
			justEaten?.GetEaten();

			source.PlayOneShot(eatingSound, 1.0f);
		}
	}
}