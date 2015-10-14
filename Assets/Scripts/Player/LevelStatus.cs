using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour
{
    public const float TOTAL_SECONDS = 10.0f;

    public int EnemyCount;
	public Text winText;
	public Text killCountText;
	public Text timerText;
	public Text crossHair;
	
	private int _killCount;
	private bool gameOver;
    private float secondsLeft;


    // Use this for initialization
    void Start () 
	{
		winText.text = "";
		_killCount = 0;
		gameOver = false;
        secondsLeft = TOTAL_SECONDS;
		DisplayKillCount ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (gameOver)
			return;

		DisplayKillCount ();

        // decrease timer to 0
        secondsLeft = Mathf.Max(secondsLeft - Time.deltaTime, 0);
        // set timer text
        timerText.text = string.Format("Time: {0}:{1:00.00}", (int)(secondsLeft / 60), secondsLeft % 60);


        if (gameOver = secondsLeft == 0)
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


