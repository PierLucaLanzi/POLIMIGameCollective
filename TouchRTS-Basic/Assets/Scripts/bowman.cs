using UnityEngine;
using System.Collections;

public class bowman : MonoBehaviour {
	
	public GameObject proiettile_prefab;
	
	GameObject player; 
	
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		InvokeRepeating("Spara", 2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Spara()
	{
		Vector3 target = player.transform.position;
		Vector3 direzione = target - transform.position;
		direzione.z = 0; 
		direzione.Normalize();
		
		GameObject proiettile = 
			Instantiate(proiettile_prefab, 
				transform.position +direzione*30f, 
				Quaternion.identity) as GameObject;
		
		proiettile.GetComponent<proiettile>().direzione = 
			direzione;
		Debug.LogError("BANG!");
	}
}
