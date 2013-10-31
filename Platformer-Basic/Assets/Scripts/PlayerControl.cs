using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	CharacterController controller;
	
	float hspeed = 200f;
	float vspeed = 400f;

	public Vector3 speed = Vector3.zero;
	
	bool flag_isjumping = false;
	bool flag_powerup = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	void Update () {
		Vector3 g = new Vector3(0, -800f, 0);
		
		if (Input.GetKey(KeyCode.A))
		{
			speed.x = -hspeed;
		} else if (Input.GetKey(KeyCode.D)) {
			speed.x = hspeed;
		} else {
			speed.x = 0f;
		}
		
		float dt = Time.deltaTime;
		
		speed = speed + g*dt;

		if (!flag_isjumping && Input.GetKeyDown(KeyCode.W))
		{
			speed.y = vspeed;
			if (flag_powerup) speed.y += 0.5f*vspeed;
			flag_isjumping = true;
		}
		
		CollisionFlags cf = controller.Move(speed*dt);
		
		if (cf==CollisionFlags.CollidedBelow)
		{	
			flag_isjumping = false;
			speed.y = 0;
		}

		if (cf==CollisionFlags.CollidedAbove)
		{	
			speed.y = 0;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("powerup"))
		{
			flag_powerup = true;
			Destroy(other.gameObject);
			
			StopCoroutine("PowerUp");
			StartCoroutine("PowerUp");
		}
	}
	
	IEnumerator PowerUp()
	{
		yield return new WaitForSeconds(5f);
		flag_powerup = false;
	}
}
