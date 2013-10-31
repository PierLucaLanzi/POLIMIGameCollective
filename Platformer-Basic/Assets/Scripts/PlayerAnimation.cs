using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	enum AnimationStatus {RunLeft, RunRight, Jump, StandLeft, StandRight};
	
	AnimationStatus animation_status = AnimationStatus.StandLeft; 
	
	PlayerControl player_control; 
	public Transform sprite_parent; 
	public OTAnimatingSprite player_sprite;
		
	// Use this for initialization
	void Start () {
		player_control = GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player_control.speed.x<0 && 
			animation_status!=AnimationStatus.RunLeft)
		{	
			sprite_parent.localScale = new Vector3(1,1,1);
			player_sprite.Play("Run");
			animation_status = AnimationStatus.RunLeft;
		} else if (player_control.speed.x>0 && 
			animation_status!=AnimationStatus.RunRight) 
		{
			sprite_parent.localScale = new Vector3(-1,1,1);
			player_sprite.Play("Run");
			animation_status = AnimationStatus.RunRight;
		} else {
			player_sprite.Play ("Stand");
			if (sprite_parent.localScale.x<0)
				animation_status = AnimationStatus.StandRight;
			else animation_status = AnimationStatus.StandLeft;
		}
		
		if (player_control.speed.y!=0 &&
			animation_status != AnimationStatus.Jump)
		{
			animation_status = AnimationStatus.Jump;
			player_sprite.Play ("Jump");
		}
	}
}
