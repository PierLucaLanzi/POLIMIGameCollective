using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Vector3 speed_vector; 
	private float speed = 300f;
	private float noise = 0.1f;
	private bool flag_moving = false;
	
	// Use this for initialization
	void Start () {
		flag_moving = false;
		
		transform.position = new Vector3(Random.Range(-350,350), -230, 0);
		speed_vector = new Vector3(Random.value*2-1f, Random.value, 0f);
		
		Debug.Log(speed_vector);
	}
	
	public void StartMoving()
	{
		flag_moving = true;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		if (Input.GetKeyUp(KeyCode.Space)) 
			flag_moving = true;
		
		//transform.position = new Vector3(Random.Range(-350,350), -230, 0);
	
		if (flag_moving) 
		{
			transform.position = transform.position+speed_vector*speed*dt;
			// opzione2
			//transform.Translate(speed_vector*speed*dt);		
		}
		
		// outside the 
		if (transform.position.y<-320)
		{
			gBreakOut.BallLost();
			transform.position = new Vector3(Random.Range(-350,350), -230, 0);
			speed_vector = new Vector3(Random.value*2-1f, Random.value, 0f);
			speed_vector.Normalize();

		}

	}
	
	void OnTriggerEnter(Collider other)
	{
		float noise_x = Random.value*2*noise-noise/2f;
		float noise_y = Random.value*2*noise-noise/2f;
		
		//Debug.Log("I HAVE BEEN HIT BY "+collision.gameObject.name+" WITH TAG <"+collision.gameObject.tag+">!");
		
		if (other.gameObject.name=="Left" || other.gameObject.name=="Right")
		{
			
			speed_vector = new Vector3(-speed_vector.x + noise_x, speed_vector.y + noise_y, speed_vector.z);
			
		} else if (other.gameObject.tag=="Brick") {
			
			float dx = Mathf.Abs(transform.position.x - other.transform.position.x)/other.transform.localScale.x;
			float dy = Mathf.Abs(transform.position.y - other.transform.position.y)/other.transform.localScale.y;
			
			if (dx>dy)
			{	
				// side collision
				speed_vector = new Vector3(-speed_vector.x + noise_x, speed_vector.y + noise_y, speed_vector.z);
			} else {
				// front collision
				speed_vector = new Vector3(speed_vector.x + noise_x, -speed_vector.y + noise_y, speed_vector.z);
			}
			
			if (other.gameObject.tag=="Brick")
			{
				gBreakOut.IncreaseScore(5);
				Destroy(other.gameObject);
			}
		} else if (other.gameObject.name=="Pad" || other.gameObject.name=="Upper") {
			
			speed_vector = new Vector3(speed_vector.x + noise_x, -speed_vector.y + noise_y, speed_vector.z);
			
			if (other.gameObject.tag=="Brick")
			{
				gBreakOut.IncreaseScore(5);
				Destroy(other.gameObject);
			}
		}
		
		speed_vector.Normalize();
		
	}
}
