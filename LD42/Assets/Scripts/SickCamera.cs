using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickCamera : MonoBehaviour
{
	public float Elasticity;
	public float Speed;
	public float MaxHeight;
	public float MinHeight;
	public Camera Camera;
	public Transform UpperCollider;
	public Transform FollowTarget;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		var toTarget = FollowTarget.position - transform.position;

		if (toTarget.sqrMagnitude > 0)
		{
			var toFly = Time.deltaTime *
				Speed *
				Mathf.Pow(toTarget.magnitude, Elasticity) * toTarget.normalized;
			if (toFly.x < 0)
				toFly.x = 0;
			var newPos = transform.position + toFly;
			newPos.y = Mathf.Clamp(newPos.y, MinHeight, MaxHeight);
			transform.position = newPos;
			//(toTarget.sqrMagnitude > toFly.sqrMagnitude ? toFly : toTarget);
		}
	}

	 /// <summary>
	 /// Callback to draw gizmos that are pickable and always drawn.
	 /// </summary>
	 void OnDrawGizmos()
	 {
		 Gizmos.DrawWireCube(UpperCollider.position + new Vector3(300,MaxHeight-transform.position.y,0),new Vector3(600,1,50));
	 }
}