using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public Text scoreText;

	private Rigidbody rb;
	private int score;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		score = 0;
		SetCountText();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		debug.Log(other.gameObject.name);
		if (other.gameObject.CompareTag("Eatable"))
		{
			score++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		scoreText.text = "Score: " + score.ToString();
	}
}
