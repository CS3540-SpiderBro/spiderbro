using UnityEngine;
using UnityEngine.UI;
using FirstPersonController = UnityStandardAssets.Characters.FirstPerson.FirstPersonController;

//added code from mouthScript into here - Greg

namespace Assets.Scripts.Player
{
    public class LevelStatus : MonoBehaviour
    {
        public int LevelSeconds = 30;
        public int EnemyCount;
        public string NextScene;
        public Text winText;
        public Text killCountText;
        public Text timerText;
        public Text crossHair;
        public GameObject pausePanel;
        static KeyCode pauseKeyCode = KeyCode.P;
        static KeyCode RestartKeyCode = KeyCode.R;
        static KeyCode QuitKeyCode = KeyCode.Q;


        mouthScript mouth;
		PlayerHealth playerHP;
        private int _killCount;
        private bool gameOver;
        private float secondsLeft;
        private bool endless;
        private FirstPersonController fpsController;

        public bool IsPaused { get; private set; }


        // Use this for initialization
        void Start()
        {
			NextScene = "";
            winText.text = "";
            _killCount = 0;
            gameOver = false;
            mouth = GameObject.FindObjectOfType(typeof(mouthScript)) as mouthScript;
            pausePanel.SetActive(false);
            Time.timeScale = 1;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            fpsController = FindObjectOfType(typeof(FirstPersonController)) as FirstPersonController;

            secondsLeft = LevelSeconds;
            endless = (LevelSeconds <= 0);
        }

        // Update is called once per frame
        void FixedUpdate()
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

            if (secondsLeft == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    string nextLevelName = "Wave" + (int.Parse(Application.loadedLevelName.Substring(4)) + 1);
                    Application.LoadLevel(nextLevelName);
                }
            }
            else if (IsPaused || gameOver)
            {
                if (Input.GetKeyDown(RestartKeyCode))
                {
                    Time.timeScale = 1;
					Debug.Log ("Pressed restart key");
                    Application.LoadLevel(Application.loadedLevelName);

                }

                if (Input.GetKeyDown(QuitKeyCode))
                {
                    // Application.Quit();
                    Application.LoadLevel("Title");
                }

            }

            if (!gameOver)
            {
                if (mouth.IsDead())
                {
                    gameOver = true;
                    UpdateWinText("You Lost!!\nPress [R] to Restart");
                }

				if (PlayerHealth.player_isDead)
                {
                    gameOver = true;
                    //Destroy (gameObject.Player_NEW);
                    UpdateWinText("You have died!\nPress [R] to Restart");

                }
                else
                {
                    if(!endless)
                    {
                        // decrease timer to 0
                        secondsLeft = Mathf.Max(secondsLeft - Time.deltaTime, 0);
                        // set timer text
                        timerText.text = string.Format("{0}:{1:00.00}", (int)(secondsLeft / 60), secondsLeft % 60);
                        // see if game is over now
                        if (secondsLeft == 0)
                        {
                            gameOver = true;
                            UpdateWinText("You have Won!!\nPress [Space] to continue");
                        }
                    }
                    else
                    {
                        timerText.text = "∞";
                    }
                    
                    // update kill counter
                    killCountText.text = _killCount.ToString();
                }
            }

			checkLevelDone ();	//check if we killed all enemies and queens and structures in scene

        }

        private void UpdateWinText(string message)
        {
            crossHair.text = string.Empty;
            winText.text = message;
            DeleteAll();
        }

        public void AddKill(int score = 1)
        {
            ++_killCount;
        }

		private void checkLevelDone()
		{
			int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
			int suicideCount = GameObject.FindGameObjectsWithTag("EnemySuicide").Length;
			int nestCount = GameObject.FindGameObjectsWithTag("Queen").Length;
			
			if(enemyCount+suicideCount+nestCount == 0)
				secondsLeft = 0;
			
		}


        void DeleteAll()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }            
            GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("spawner");
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                Destroy(spawnObjects[i]);
            }

			//suicide roaches need special treatment :/
			GameObject[] suicideRoaches = GameObject.FindGameObjectsWithTag ("EnemySuicide");
			for (int i = 0; i < suicideRoaches.Length; i++)
			{
				Destroy(suicideRoaches[i]);
			}

        }
    }
}