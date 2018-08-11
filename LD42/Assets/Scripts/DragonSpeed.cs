using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpeed : MonoBehaviour 
{
	public float Speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Speed * Time.deltaTime;
	}
}
