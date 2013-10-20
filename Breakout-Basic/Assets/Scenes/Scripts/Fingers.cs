using UnityEngine;
using System.Collections;

public class Fingers : MonoBehaviour {
	public Pad pad;
	public Ball ball;
	
	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDrag()
	{
		if (gameObject.name=="FingerLeft" && pad.transform.position.x>-345)
			pad.transform.Translate(Vector3.left*pad.speed);
		else if (gameObject.name=="FingerRight"&& pad.transform.position.x<345)
			pad.transform.Translate(Vector3.right*pad.speed);
		else {
			ball.StartMoving();		
		}
	}
}
