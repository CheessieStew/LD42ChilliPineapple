using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickCamera : MonoBehaviour {
	public float Elasticity = 1.1f;
	public float Speed = 4;
	public float MaxHeight = 31.76f;
	public float MinHeight = -1.61f;
	public new Camera camera;
	public Transform upperCollider;
	public Transform targetToFollow;

	void Reset() {
		SetupNeededFields();
	}
	void OnValidate() {
		SetupNeededFields();
	}

	void Update() {
		var toTarget = targetToFollow.position - transform.position;

		if (toTarget.sqrMagnitude > 0) {
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

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(
			upperCollider.position + new Vector3(300, MaxHeight - transform.position.y, 0),
			new Vector3(600, 1, 50)
		);
	}

	private void SetupNeededFields() {
		if (!camera) {
			camera = GetComponentInChildren<Camera>();
			if (!camera) {
				throw new UnityException("CameraRig needs Camera assigned to props or in children.");
			}
		}

		if (!upperCollider) {
			upperCollider = transform.Find("Upper Collider");
			if (!upperCollider) {
				throw new UnityException("CameraRig needs upperCollider assigned to props or in children.");
			}
		}

		if (!targetToFollow) {
			targetToFollow = GameObject.FindGameObjectWithTag("Player").transform;
			if (!targetToFollow) {
				throw new UnityException("CameraRig needs targetToFollow assigned to props or in children.");
			}
		}
	}
}