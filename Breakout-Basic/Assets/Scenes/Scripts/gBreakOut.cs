using UnityEngine;
using System.Collections;

public class gBreakOut : MonoBehaviour {
	
	static int score = 0;
	static TextMesh score_board;
	
	static int no_balls = 3;
	static TextMesh no_balls_board;
	
	static int no_bricks;
	
	static public AudioSource brick_sound;
	static public AudioSource wall_sound;
	static public AudioSource pad_sound;
	
	// Use this for initialization
	void Start () {
		
		score = 0;
		no_balls = 3;
		
		score_board = GameObject.Find ("score_board").GetComponent<TextMesh>();
		score_board.text = score.ToString("0000");
		
		no_balls_board = GameObject.Find ("no_balls_board").GetComponent<TextMesh>();
		no_balls_board.text = no_balls.ToString("0");
		
		if (no_balls_board==null) Debug.LogError("no_balls_board not found");
		if (score_board==null) Debug.LogError("score_board not found");
		
		no_bricks = GameObject.FindGameObjectsWithTag("Brick").Length;
		
		Debug.Log("THERE ARE "+no_bricks+" BRICKS");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	static public void BallLost()
	{
		Debug.Log("Ball Lost");
		no_balls--;
		
		no_balls_board.text = no_balls.ToString();
		
		if (no_balls<=0)
			Application.LoadLevel("SceneEnd");
	}

	static public void IncreaseScore(int points)
	{
		score = score + points;		
		score_board.text = score.ToString("0000");
	}
	
	static public void RemoveBrick()
	{
		no_bricks = no_bricks - 1;
		if (no_bricks == 0)
		{
			Application.LoadLevel("SceneEnd");	
		}
	}

	static public void SoundBrick()
	{
		brick_sound.Play();
	}

	static public void SoundWall()
	{
		wall_sound.Play();
	}

	static public void SoundPad()
	{
		pad_sound.Play();
	}
}
