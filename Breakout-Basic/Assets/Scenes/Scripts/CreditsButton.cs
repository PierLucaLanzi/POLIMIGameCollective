using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
			Application.LoadLevel("Menu");
	}
	
	void OnMouseUp()
	{
		Debug.LogError(gameObject.name+" BEEN CLICKED!");	
		
		if (gameObject.name=="polimigamecollective_button")
		{
			Application.OpenURL("http://www.polimigamecollective.org");
		} else if (gameObject.name=="home_button")
		{
			Application.LoadLevel("Menu-Simple");
		}
	}
	
	//Color bo_blue = Color(60f/255f, 72f/255f, 200f/255f);
	//Color bo_yellow = Color(162f/255f, 162f/255f, 42f/255f);
	
}
