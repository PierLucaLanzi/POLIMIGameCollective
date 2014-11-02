using UnityEngine;
using System.Collections;

public class gDogFight : MonoBehaviour {

	public enum eEnemies {eBlueEnemy, eOrangeEnemy, eAlienEnemy};
	
	public static int id = 0;

	private int no_blue_bullets = 0;
	private int no_orange_bullets = 0;

	private int max_blue_bullets = 3;
	private int max_orange_bullets = 3;

	public int score_orange = 0;
	public int score_blue = 0;

	public int no_lives_orange = 3;
	public int no_lives_blue = 3;

	public AudioSource blue_fighter_fires;
	public AudioSource orange_fighter_fires;

	public bool flag_blue_enabled = true;
	public bool flag_orange_enabled = true;

	public float seconds_between_shoots = 1f;

	public SpriteRenderer[]	lives_orange = new SpriteRenderer[3];
	public SpriteRenderer[]	lives_blue = new SpriteRenderer[3];

	void Start()
	{
		for(int i=0; i<3; i++)
		{
			lives_blue[i].enabled = true;
			lives_orange[i].enabled = true;
		}
	}

	public void ShipScored(eEnemies color, int score=10)
	{

	}

	public void ShipDestroyed(eEnemies color)
	{

		switch (color)
		{
		case eEnemies.eOrangeEnemy:
			no_lives_orange--;

			if (no_lives_orange>=0) lives_orange[no_lives_orange].enabled = false;

			if (no_lives_orange<=0) GameOver();
			break;
		case eEnemies.eBlueEnemy:
			no_lives_blue--;
			if (no_lives_blue>=0) lives_blue[no_lives_blue].enabled = false;
			if (no_lives_blue<=0) GameOver();
			break;
		}
	}

	public bool ShipAllowedToShoot(eEnemies color)
	{
		if (color==eEnemies.eBlueEnemy)
			return no_blue_bullets<max_blue_bullets;

//		if (color==eEnemies.eOrangeEnemy)
//			return no_orange_bullets<max_orange_bullets;

		return no_orange_bullets<max_orange_bullets;

	}

	public void ShipShoots(eEnemies color)
	{
		switch (color)
		{
		case eEnemies.eBlueEnemy:
			no_blue_bullets++;
			break;
		case eEnemies.eOrangeEnemy:
			no_orange_bullets++;
			break;
		}
	}

	public void MissileHits(eEnemies color)
	{
		switch (color)
		{
		case eEnemies.eBlueEnemy:
			no_blue_bullets--;
			break;
		case eEnemies.eOrangeEnemy:
			no_orange_bullets--;
			break;
		}
	}

	public void MissileDestroyed(eEnemies color)
	{
		switch (color)
		{
		case eEnemies.eBlueEnemy:
			no_blue_bullets--;
			break;
		case eEnemies.eOrangeEnemy:
			no_orange_bullets--;
			break;
		}
	}

	void Awake() {
		id ++;
	}

	void GameOver ()
	{
		Application.LoadLevel ("GameOver");
	}
}
