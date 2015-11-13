using UnityEngine;
using UnityEngine.UI;
using FirstPersonController = UnityStandardAssets.Characters.FirstPerson.FirstPersonController;

//added code from mouthScript into here - Greg

namespace Assets.Scripts.Player
{
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

            fpsController = FindObjectOfType(typeof(FirstPersonController)) as FirstPersonController;
        }
	
        // Update is called once per frame
        void Update ()
        {
        if (Input.GetKeyDown(pauseKeyCode) && !gameOver)
            {
                IsPaused = !IsPaused;
                pausePanel.SetActive(IsPaused);
                Time.timeScale = IsPaused ? 0 : 1;
                Cursor.lockState = IsPaused ? CursorLockMode.None : CursorLockMode.Locked;
                Cursor.visible = fpsController.paused = IsPaused;
            }

            if (Input.GetKeyDown("f12"))
            {
                Screen.fullScreen = true;
            }

        if(IsPaused || gameOver)
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

        if (!gameOver)
        {
            DisplayKillCount();

            if (mouth.IsDead())
            {
                gameOver = true;
                UpdateWinText("You Lost!!");
            }
            else
            {
                // decrease timer to 0
                secondsLeft = Mathf.Max(secondsLeft - Time.deltaTime, 0);
                // set timer text
                timerText.text = string.Format("{0}:{1:00.00}", (int)(secondsLeft / 60), secondsLeft % 60);
                // see if game is over now
                if (secondsLeft == 0)
                {
                    gameOver = true;
                    UpdateWinText("You have Won!!");
                }
            }
        }
        }

        private void UpdateWinText(string message)
        {
            crossHair.text = string.Empty;
            winText.text = message + "\nPress [R] to Restart";
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

        }
    }
}


