using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour {
	public int EnemyCount;
	public Text winText;
	public Text killCountText;
	public Text timerText;
	public Text crossHair;

	public float timeSeconds = 10.0f;
	
	private int _killCount;
	private bool gameOver;

	// Use this for initialization
	void Start () 
	{
		winText.text = "";
		_killCount = 0;
		gameOver = false;
		DisplayKillCount ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (gameOver)
			return;

		DisplayKillCount ();

		timeSeconds -= Time.deltaTime;
		if (timeSeconds > 0)
			timerText.text = string.Format ("Timer: {0}", (int)timeSeconds);
		else
			timerText.text = string.Format ("Timer: {0}", 0);
			

		if (gameOver = timeSeconds < 0)
		{
			Destroy(crossHair);
			winText.text = "Time is Up!!";
		} 
		else if ( gameOver = EnemyCount == _killCount)
		{
			Destroy (crossHair);
			winText.text = "You Win!";
		}
	}

	public void AddKill(int score = 1)
	{
		++_killCount;
		DisplayKillCount();
	}

	void DisplayKillCount()
	{
		killCountText.text = string.Format("Kill Count: {0}", _killCount.ToString());
		
	}
}


