using UnityEngine;
using System.Collections;

public class DogFight : MonoBehaviour {

	// global data
	private gDogFight gdf;

	public float rotation_speed = 3.14f/8f;

	public float fighter_speed = 2f;

	public gDogFight.eEnemies color;
	
	private bool flag_fire_enabled = true;

	//	private Animator animator;

	Rigidbody2D rigidbody;

	public GameObject missile_prefab = null;

	public float pause_between_shoots = .5f;

	public ParticleSystem explosion;

	private SpriteRenderer sprite; 

	private bool flag_exploding = false;

	private KeyCode thrust;
	private KeyCode left;
	private KeyCode right;
	private KeyCode fire;

	private bool flag_invincible = false;
	private float t_invincibility = 0.1f;

	public AudioSource as_fire;
	public AudioSource as_explode;


	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>() as Rigidbody2D;
		sprite = GetComponent<SpriteRenderer>() as SpriteRenderer;

		switch (color)
		{
		case gDogFight.eEnemies.eBlueEnemy:
			thrust = KeyCode.W;
			left = KeyCode.A;
			right = KeyCode.D;
			fire = KeyCode.E;
			break;
		case gDogFight.eEnemies.eOrangeEnemy:
			thrust = KeyCode.UpArrow;
			left = KeyCode.LeftArrow;
			right = KeyCode.RightArrow;
			fire = KeyCode.RightShift;
			break;
		}

		//explosion = GetComponent<ParticleSystem>() as ParticleSystem;
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		//if (other==null) return;

		if (flag_invincible) return;

		if (other.gameObject.tag=="Fighter")
		{
			Debug.LogError(gameObject.name+"HAS BEEN HIT BY "+other.gameObject.name);

			Debug.LogError("BOTH SHIPS ARE DESTROYED");

			StartCoroutine(Exploding());
		}

		if (other.gameObject.tag=="Missile")
		{
			gDogFight.eEnemies missile_color = other.gameObject.GetComponent<Missile>().color;

			//Debug.LogError(color.ToString()+" DESTROYED BY MISSILE FROM "+missile_color.ToString());

			gdf.MissileDestroyed(missile_color);
			gdf.ShipDestroyed(color);
			Destroy(other.gameObject);
			StartCoroutine(Exploding());
		}
	}
	

	// Use this for initialization
	void Start () {
		gdf = GameObject.Find("gDogFight").GetComponent<gDogFight>();
//		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		//if (color==gDogFight.eEnemies.eOrangeEnemy) return;

		if (Input.GetKey(left))
		{
			transform.Rotate (Vector3.forward * 90 * Time.deltaTime);
		} 

		if (Input.GetKey(right)) {
			
			transform.Rotate (Vector3.forward * -90 * Time.deltaTime);
		} 

		if (Input.GetKey(thrust)) {			
			rigidbody.AddForce(transform.up*fighter_speed);
		} 

		if (Input.GetKeyDown (fire) && flag_fire_enabled) {

			as_fire.Play();

			GameObject bullet = Instantiate(missile_prefab, transform.position+transform.up*.52f, transform.rotation) as GameObject;
			bullet.GetComponent<Missile>().flag_fired = true;
			bullet.GetComponent<Missile>().color = this.color;

			gdf.ShipShoots(color);

			flag_fire_enabled = false;
			StartCoroutine(PauseFire());

		} 
	}

	IEnumerator PauseFire()
	{
		yield return new WaitForSeconds(pause_between_shoots);		
		flag_fire_enabled = true;
	}

	IEnumerator Exploding()
	{
		as_explode.Play();
		flag_invincible = true;
		sprite.enabled = false;
		explosion.Play();

		yield return new WaitForSeconds(explosion.duration*2f);
		explosion.Stop();

		transform.position = new Vector3(Random.Range(-6f,6f), Random.Range (-4f,3.5f), 0f);

#if DOGFIGHT_FIXEDSTART
		if (color == gDogFight.eEnemies.eBlueEnemy)
			transform.position = new Vector3(-5f, 0f, 0f);
		else transform.position = new Vector3(5f, 0f, 0f);
#endif

		transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

		rigidbody.velocity = Vector3.zero;
		sprite.enabled = true;
		StartCoroutine(Invincibility());
	}

	/**
     * Coroutine to create a flash effect on all sprite renderers passed in to the function.
     *
     * @param sprites   a sprite renderer array
     * @param numTimes  how many times to flash
     * @param delay     how long in between each flash
     * @param disable   if you want to disable the renderer instead of change alpha
     */

	IEnumerator FlashSprites(SpriteRenderer[] sprites, int numTimes, float delay, bool disable = false) {
		// number of times to loop
		for (int loop = 0; loop < numTimes; loop++) {            
			// cycle through all sprites
			for (int i = 0; i < sprites.Length; i++) {                
				if (disable) {
					// for disabling
					sprites[i].enabled = false;
				} else {
					// for changing the alpha
					sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 0.5f);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
			
			// cycle through all sprites
			for (int i = 0; i < sprites.Length; i++) {
				if (disable) {
					// for disabling
					sprites[i].enabled = true;
				} else {
					// for changing the alpha
					sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 1);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
		}
	}

	IEnumerator Invincibility() {

		flag_invincible = true;

		int numTimes = 15; 
		float delay = 0.2f;
		bool disable = false;

		// number of times to loop
		for (int loop = 0; loop < numTimes; loop++) {            
			// cycle through all sprites
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
			yield return new WaitForSeconds(delay);
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1.0f);
			yield return new WaitForSeconds(delay);
		}
		flag_invincible = false;

	}

}
