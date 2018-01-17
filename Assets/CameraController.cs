using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	public float distanceUp;
	public float distanceBehind;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		// Updates camera position at the end of frame to follow player
		transform.position = target.position + (Vector3.up * distanceUp) - (Vector3.forward * distanceBehind);
	}
}
