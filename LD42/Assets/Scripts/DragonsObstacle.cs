using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsObstacle : MonoBehaviour {
	public float Length;
	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(transform.position + new Vector3(Length * 0.5f,7.5f,0), new Vector3(Length, 15, 15));
	}
}