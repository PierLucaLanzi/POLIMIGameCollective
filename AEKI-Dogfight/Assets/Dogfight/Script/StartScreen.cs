using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
			Application.LoadLevel ("Dogfight");
	}
}
