using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyDrake {
	public class DragonsPath : MonoBehaviour {
		public List<Obstacle> ObstaclePrefabs;
		public Transform SpotsParent;
		public float Length;

		public float ObstacleSpacingRandomizer;

		void Start() {
			Transform prevSpot = null;
			float prevLength = 0;
			Debug.Assert(SpotsParent != null, "Spots Parent can't be null");

			foreach (Transform spot in SpotsParent) {
				if (
					prevSpot == null ||
					prevSpot.position.x + prevLength < spot.position.x
				) {
					var obstacle = Instantiate(
						original: ObstaclePrefabs[Mathf.FloorToInt(Random.value * ObstaclePrefabs.Count)],
						position: spot.position,
						rotation: Quaternion.identity,
						parent: spot);
					prevSpot = spot;
					prevLength = obstacle.Length + (Random.value - 0.5f) * ObstacleSpacingRandomizer;
				}
			}
		}

		void OnDrawGizmos() {
			Gizmos.DrawWireCube(transform.position + new Vector3(Length * 0.5f, 15, 0), new Vector3(Length, 30, 50));
			if (SpotsParent != null)
				foreach (Transform spot in SpotsParent)
					Gizmos.DrawWireSphere(spot.position, 3);
		}
	}
}