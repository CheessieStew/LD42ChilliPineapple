using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour {
	public int ChunkWidth = 98;

	public GameObject ChunkPrefab;

	private Transform _chunks;

	void Awake() {
		_chunks = transform.Find("Chunks");

		Debug.Assert(
			_chunks != null,
			"WorldBuilder must have a Chunks child with starting chunks."
		);
		Debug.Assert(
			ChunkPrefab != null,
			"ChunkPrefab can't be empty."
		);
	}

	void RemoveLeftiestChunk() {
		Destroy(_chunks.GetChild(0).gameObject);
	}

	void AddNewChunk() {
		var last = _chunks.GetChild(_chunks.childCount - 1);
		var pos = last.position.x + ChunkWidth;

		GameObject newChunk = Instantiate<GameObject>(
			original: ChunkPrefab,
			parent: _chunks
		);
		newChunk.transform.localPosition = new Vector3(pos, 0, 0);
	}

	public void OnProgress() {
		RemoveLeftiestChunk();
		AddNewChunk();
	}
}