using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour {
	
	public GameObject horizontal;
	public GameObject vertical;
	
	Vector3 hfinal;
	Vector3 vfinal;
	
	// Use this for initialization
	void Start () {
		hfinal = new Vector3(-horizontal.transform.position.x,
			horizontal.transform.position.y,
			horizontal.transform.position.z);
		vfinal = new Vector3(vertical.transform.position.x,
			-vertical.transform.position.y,
			vertical.transform.position.z);
			
		Hashtable hht = new Hashtable();
		hht.Add("looptype","pingPong");
		hht.Add("time", 5f);
		hht.Add("x",-horizontal.transform.position.x);
		hht.Add ("easetype",iTween.EaseType.easeInOutSine);
		iTween.MoveTo(horizontal, hht);

		Hashtable vht = new Hashtable();
		vht.Add("looptype","pingPong");
		vht.Add("y",-vertical.transform.position.y);
		vht.Add ("easetype",iTween.EaseType.easeInOutSine);
		vht.Add ("delay",2f);
		
		iTween.MoveTo(vertical, vht);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
