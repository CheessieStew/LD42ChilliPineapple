using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
	const int CHUNK_WIDTH = 98;

	public GameObject ChunkPrefab;
	public Transform InitialChunkTransform;

	void Awake()
	{
		Debug.Assert(
			ChunkPrefab != null,
			"ChunkPrefab can't be empty."
		);
		Debug.Assert(
			InitialChunkTransform != null,
			"InitialChunkTransform can't be empty."
		);
	}
}