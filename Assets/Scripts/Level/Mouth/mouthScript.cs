using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// mother base controls and actions when base is destroyed
/// </summary>
public class mouthScript : MonoBehaviour {
    public int hitPoints;
    bool gamedone = false;
    bool mouthDead = false;
    GameObject[] gameObjects;
	GameObject[] spawnObjects;
	GameObject[] turretObjects;
	GameObject timer;
    public Slider mouthHealthSlider;
	// Use this for initialization
	void Start () {
        //GameObject canvas = GameObject.Find ("Canvas");
        gamedone = false;
        mouthDead = false;
        mouthHealthSlider.maxValue = hitPoints;
        mouthHealthSlider.value = hitPoints;
    }

    void OnCollisionEnter(Collision touched)
    {

        if (touched.gameObject.tag == "Enemy")
        {
            hitPoints = hitPoints > 1 ? hitPoints - 1 : 0;
            
        }
    }

    // Update is called once per frame
    void Update () {

        //Text timerObject = GameObject.Find("TimerText").GetComponent<Text>();
        //if (timerObject.text == "Time: 0:00.00" && gamedone == false)
        //{
        //    gameWin();
        //    gamedone = true;
        //}
        mouthHealthSlider.value = hitPoints;
        if (hitPoints <= 0)
        {
            //Debug.Log("MOUTH IS DESTROYED");
            //Destroy(this.gameObject);
			//gameOver();
            //gamedone = true;
            mouthDead = true;

        }
	}

    public bool IsDead()
    {
        return mouthDead;
    }
 //   void gameWin()
 //   {
 //       Text textobject = GameObject.Find("WinningText").GetComponent<Text>();
 //       textobject.text = "You Won!";
 //       DeleteAll();
 //   }
	// void gameOver()
	//{
	//	Text textobject = GameObject.Find("WinningText").GetComponent<Text>();
	//	textobject.text = "You Lost!";
	//	DeleteAll ();
	//}

	//void DeleteAll()
	//{
	//	gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
	//	for(int i = 0; i < gameObjects.Length; i++)
	//	{
	//		Destroy(gameObjects[i]);
	//	}
	//	spawnObjects = GameObject.FindGameObjectsWithTag("spawner");
	//	for(int i = 0; i < spawnObjects.Length; i++)
	//	{
	//		Destroy(spawnObjects[i]);
	//	}		
		
 //       Text timerObject = GameObject.Find("TimerText").GetComponent<Text>();
 //       timerObject.text = "Time: 0:00.00";

 //   }
}
