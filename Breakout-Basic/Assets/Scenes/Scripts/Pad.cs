using UnityEngine;
using System.Collections;

public class Pad : MonoBehaviour {
	
	public float speed = 10f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x>-345)
		{
			transform.Translate(Vector3.left*speed);			
		} else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x<345) {
			transform.Translate(Vector3.right*speed);
			
		}
	}
}
