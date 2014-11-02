using UnityEngine;
using System.Collections;

public class global : MonoBehaviour {

	public gDogFight.eEnemies wins;

	void Awake () {
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
