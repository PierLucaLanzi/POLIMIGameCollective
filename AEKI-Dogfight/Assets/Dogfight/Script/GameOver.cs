using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public GameObject wins_orange;
	public GameObject wins_blue;
	public global g;

	//	private bool flag_can_replay = false;
	
	// Use this for initialization
	void Start () {
		wins_orange.SetActive(false);
		wins_blue.SetActive(false);

		g = GameObject.FindObjectOfType(typeof(global)) as global;

		if (g.wins==gDogFight.eEnemies.eOrangeEnemy)
			wins_orange.SetActive(true);
		else wins_blue.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
			Application.LoadLevel("DogFight");
	}
}
