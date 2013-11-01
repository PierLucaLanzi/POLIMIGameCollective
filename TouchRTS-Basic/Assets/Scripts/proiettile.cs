using UnityEngine;
using System.Collections;

public class proiettile : MonoBehaviour {

	public Vector3 direzione;
	float speed = 150f;
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position 
			+ direzione*speed*Time.deltaTime;
		
		if (Mathf.Abs (transform.position.x)>2000 ||
			Mathf.Abs (transform.position.y)>2000)
			Destroy(gameObject);
			
	}
}
