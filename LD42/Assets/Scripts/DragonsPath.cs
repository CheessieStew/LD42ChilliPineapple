using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsPath : MonoBehaviour {
	public List<DragonsObstacle> ObstaclePrefabs;
	public Transform SpotsParent;
	public float Length;

	public float ObstacleSpacingRandomizer;
	private System.Random _rng = new System.Random();
	// Use this for initialization
	void Start () {
		Transform prevSpot = null;
		DragonsObstacle prevObstacle = null;
		float prevLength = 0;
		if (SpotsParent != null)
			foreach(Transform spot in SpotsParent)
			{
				if (prevSpot == null || prevObstacle == null
					|| prevSpot.position.x + prevLength < spot.position.x)
				{
					prevObstacle = Instantiate(ObstaclePrefabs[_rng.Next() % ObstaclePrefabs.Count], spot.position, Quaternion.identity, spot);
					prevSpot = spot;
					prevLength = prevObstacle.Length + (Random.value - 0.5f) * ObstacleSpacingRandomizer;
				}

			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position + new Vector3(Length * 0.5f,15,0), new Vector3(Length, 30, 50));
		if (SpotsParent != null)
			foreach(Transform spot in SpotsParent)
				Gizmos.DrawWireSphere(spot.position,3);
	}
}
