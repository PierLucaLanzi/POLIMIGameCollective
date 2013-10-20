using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseUp()
	{
		Debug.LogError(gameObject.name+" BEEN CLICKED!");	
		
		if (gameObject.name=="play_button")
		{
			Application.LoadLevel("Breakout");	
		} else if (gameObject.name=="credits_button") {
			Application.LoadLevel("Credits");	
		}
	}
}
