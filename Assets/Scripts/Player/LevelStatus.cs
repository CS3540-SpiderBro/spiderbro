using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//added code from mouthScript into here - Greg
public class LevelStatus : MonoBehaviour
{
    public float TOTAL_SECONDS = 10.0f;

    public int EnemyCount;
	public Text winText;
	public Text killCountText;
	public Text timerText;
	public Text crossHair;
    public GameObject pausePanel;
    public KeyCode pauseKeyCode;
    public KeyCode RestartKeyCode;
    public KeyCode QuitKeyCode;

    GameObject[] gameObjects;
    GameObject[] spawnObjects;
    mouthScript mouth;
    private int _killCount;
	private bool gameOver;
    private float secondsLeft;
    private FirstPersonController fpsController;

    public bool IsPaused { get; private set; }


    // Use this for initialization
    void Start () 
	{

		winText.text = "";
		_killCount = 0;
		gameOver = false;
        secondsLeft = TOTAL_SECONDS;
		DisplayKillCount ();
        mouth = GameObject.FindObjectOfType(typeof(mouthScript)) as mouthScript;
        pausePanel.SetActive(false);
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpsController = GetComponent<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(pauseKeyCode))
        {
            IsPaused = !IsPaused;
            pausePanel.SetActive(IsPaused);
            Time.timeScale = IsPaused ? 0 : 1;
            Cursor.lockState = IsPaused ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = IsPaused;
        }

        if (Input.GetKeyDown("f12"))
        {
            Screen.fullScreen = true;
        }

        if(IsPaused)
        {
            if (Input.GetKeyDown(RestartKeyCode))
            {
                Time.timeScale = 1;
                Application.LoadLevel(Application.loadedLevelName);
            }

            if(Input.GetKeyDown(QuitKeyCode))
            {
                // Application.Quit();
                Application.LoadLevel("Title");
            }
        }
	

		DisplayKillCount ();
        
        if(gameOver = mouth.IsDead())
        {

            UpdateWinText("You Lost!!");

            return;

        }
        // decrease timer to 0
        secondsLeft = Mathf.Max(secondsLeft - Time.deltaTime, 0);
        // set timer text
        timerText.text = string.Format("{0}:{1:00.00}", (int)(secondsLeft / 60), secondsLeft % 60);


        if (gameOver = secondsLeft == 0)
		{

            UpdateWinText("You have Won!!");
		    return;
		} 
		//else if ( gameOver = EnemyCount == _killCount)
		//{
		//	Destroy (crossHair);
		//	winText.text = "You Win!";
		//}

	}

    private void UpdateWinText(string message)
    {
        crossHair.text = string.Empty;
        winText.text = string.Format("{0}\nPress 'R' to restart", message); //changed time is up to You have Won, and call DeleteAll method
        DeleteAll();
    }

    public void AddKill(int score = 1)
	{
		++_killCount;
		DisplayKillCount();
	}

	void DisplayKillCount()
	{
		killCountText.text = _killCount.ToString();
		
	}


    void DeleteAll()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        spawnObjects = GameObject.FindGameObjectsWithTag("spawner");
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            Destroy(spawnObjects[i]);
        }
              
        timerText.text = "0:00.00";

    }
}


