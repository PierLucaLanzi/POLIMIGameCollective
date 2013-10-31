using UnityEngine;
using System.Collections;

/// <summary>
/// Camera shift.
/// Simple script that moves the camera at a predefined speed.
/// Attach it to the camera to put it at work
/// </summary>

public class CameraShift : MonoBehaviour {
	
	public float speed = 50f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = 
			new Vector3(transform.position.x+speed*Time.deltaTime,
				transform.position.y,
				transform.position.z);
	}
}
