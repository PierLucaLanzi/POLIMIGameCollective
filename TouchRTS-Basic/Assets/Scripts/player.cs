using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public float speed = 50f;
	public int health = 100;
	CharacterController controller;
	GameObject healthLevel;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		healthLevel = GameObject.Find ("HealthLevel");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target = 
			Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 direzione = target - transform.position;
		direzione.z = 0; 
		direzione.Normalize();
		controller.Move (direzione*speed*Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("nemico"))
		{	
			Debug.LogError("HELP ME!");
			health = health - 10;
			
		} else if (other.gameObject.CompareTag("proiettile")) {
			health = health - 5;
			
			Destroy(other.gameObject);
		} else if (other.gameObject.CompareTag("porta")) {
			Application.LoadLevel("NextLevel");
		}
		
		healthLevel.GetComponent<TextMesh>().text 
			= health.ToString();
		
		if (health<=0) Application.LoadLevel("GameOver");
	}
}
