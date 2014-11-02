using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	private static gDogFight gdf;
	
	public Vector3				direzione;
	public gDogFight.eEnemies 	color;

	public bool flag_fired = false; 
	float bullet_speed = 2f;

	void Awake ()
	{
		gdf = GameObject.FindObjectOfType(typeof(gDogFight)) as gDogFight;
	}

	void Update () {

		if (!flag_fired) return;

		transform.position = transform.position + transform.up*Time.deltaTime*bullet_speed;
		
		if (Mathf.Abs (transform.position.x)>7f ||
		    Mathf.Abs (transform.position.y)>5f)
		{
			Destroy(gameObject);
			gdf.MissileDestroyed(color);
		}
	}
}
