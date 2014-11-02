using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	float secs = 2f;				// number of seconds to wait

	public GameObject	splash;		// splash screen that is not shown in pro
	public GameObject	pgc;		// polimi game collective splash
	public GameObject	guests;		// guest collaborators splash

	public string next_scene = string.Empty;

	// Use this for initialization
	void Start () {
#if UNITY_PRO 
		splash.enable = false;
#endif
		StartCoroutine (ShowSplashScreens ());
	}
	
	IEnumerator ShowSplashScreens()
	{

#if !UNITY_PRO
		yield return new WaitForSeconds(secs);
		splash.SetActive(false);
#endif
		yield return new WaitForSeconds(secs);
		pgc.SetActive(false);

		yield return new WaitForSeconds(secs);

		Application.LoadLevel(next_scene);
	}
}
