using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTrigger : MonoBehaviour
{
	void OnDrawGizmosSelected()
	{
		Debug.Log("Drawing gizmos");
		Gizmos.color = new Color(0.6f, 0.8f, 0, 0.2F);
		Gizmos.DrawCube(transform.position + new Vector3(0, 20, 0), new Vector3(30, 50, 30));
	}
}