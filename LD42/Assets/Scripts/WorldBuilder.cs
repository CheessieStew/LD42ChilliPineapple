using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDrake {
	public class WorldBuilder : MonoBehaviour {
		public DragonsPath ChunkTemplate;

		private Transform _chunks;

		void Awake() {
			_chunks = transform.Find("Chunks");

			Debug.Assert(
				_chunks != null,
				"WorldBuilder must have a Chunks child with starting chunks."
			);
			Debug.Assert(
				ChunkTemplate != null,
				"ChunkPrefab can't be empty."
			);
		}

		void RemoveLeftiestChunk() {
			Destroy(_chunks.GetChild(0).gameObject);
		}

		void AddNewChunk() {
			var last = _chunks.GetChild(_chunks.childCount - 1);

			GameObject newChunk = Instantiate<GameObject>(
				original: ChunkTemplate.gameObject,
				parent: _chunks
			);
			newChunk.transform.localPosition =
				new Vector3(ChunkTemplate.Length, 0, 0) + last.localPosition;
		}

		public void OnProgress() {
			RemoveLeftiestChunk();
			AddNewChunk();
		}
	}
}