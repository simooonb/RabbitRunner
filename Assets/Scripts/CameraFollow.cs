using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	float zOffset;

	// Use this for initialization
	void Start () {
		zOffset = transform.position.z - target.position.z;
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + zOffset);

		transform.position = targetPosition;
	}
}
