using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsPath : MonoBehaviour {
	public List<GameObject> RollGroups;
	public float Length;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(transform.position + new Vector3(Length * 0.5f,15,0), new Vector3(Length, 30, 50));
	}
}
