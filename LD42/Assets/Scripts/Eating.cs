using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eating : MonoBehaviour
{
	public Text scoreText;
	public AudioClip eatingSound;

	private Eatable justEaten;
	private int score;
	private AudioSource source;

	// Use this for initialization
	void Start()
	{
		source = GetComponent<AudioSource>();
		score = 0;
		SetCountText();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Eatable"))
		{
			score++;
			SetCountText();

			justEaten = other.gameObject.GetComponent<Eatable>();
			justEaten?.GetEaten();

			source.PlayOneShot(eatingSound, 1.0f);
		}
	}

	void SetCountText()
	{
		if (scoreText == null)
			return;
		scoreText.text = "Score: " + score.ToString();
	}
}