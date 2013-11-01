using UnityEngine;
using System.Collections;

public class nemico : MonoBehaviour {
	
	float speed = 80f;
	CharacterController controller;
	GameObject player; 
	
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target = player.transform.position;
		Vector3 direzione = target - transform.position;
		direzione.z = 0; 
		direzione.Normalize();
		controller.Move (direzione*speed*Time.deltaTime);
	}
}
