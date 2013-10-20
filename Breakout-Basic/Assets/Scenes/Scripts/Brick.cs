using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	int count;
	
	// Use this for initialization
	void Start () {
		count = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void InitCount()
	{
		count = 1;
	}
		
	//void OnCollisionEnter(Collision collision)
	//{
		//if (collision.gameObject.name=="Ball")
		//{
			//Debug.Log (collision.gameObject.name+" GOT ME!");	
		//}
	//}
	
	/*public void DecreaseCount()
	{
		count --;
		if (count==0) Destroy(this);
	}*/
}
