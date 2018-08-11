using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour 
{
	public int Value;
	
	public void GetEaten() {
		Debug.Log("Eaten for " + Value);
        Destroy(gameObject, 1);
	}
}
