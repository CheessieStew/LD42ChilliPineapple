using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTrigger : MonoBehaviour {
	public WorldBuilder WorldBuilder;

	void Awake() {
		Debug.Assert(WorldBuilder != null, "World Builder script has to exist on World");
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(0.6f, 0.8f, 0, 0.2F);
		Gizmos.DrawCube(transform.position + new Vector3(0, 0, 0), new Vector3(30, 50, 60));
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			Debug.Log("collided!");
			WorldBuilder.OnProgress();
			transform.position += new Vector3(WorldBuilder.ChunkTemplate.Length, 0, 0);
		}
	}
}