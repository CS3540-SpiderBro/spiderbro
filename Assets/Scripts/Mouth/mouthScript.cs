using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// mother base controls and actions when base is destroyed
/// </summary>
public class mouthScript : MonoBehaviour {
    public int health;
    public int dmg;
	GameObject[] gameObjects;
	GameObject[] spawnObjects;
	GameObject[] turretObjects;
	GameObject timer;
	// Use this for initialization
	void Start () {
		//GameObject canvas = GameObject.Find ("Canvas");

	}

    void OnCollisionEnter(Collision touched)
    {

        if (touched.gameObject.tag == "Enemy")
        {
            damage(dmg);
            Debug.Log("MOUTH IS DAMAGED!!!!!");
            
        }
    }

    // Update is called once per frame
    void Update () {



        if (health <= 0)
        {
            Debug.Log("MOUTH IS DESTROYED");
            //Destroy(this.gameObject);
			gameOver();

        }
	}

    public void damage(int dam)
    {
        health = health - dam;
    }

	 void gameOver()
	{
		Text textobject = GameObject.Find("WinningText").GetComponent<Text>();
		textobject.text = "You Lost!";
		DeleteAll ();
	}

	void DeleteAll()
	{
		gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
		for(int i = 0; i < gameObjects.Length; i++)
		{
			Destroy(gameObjects[i]);
		}
		spawnObjects = GameObject.FindGameObjectsWithTag("spawner");
		for(int i = 0; i < spawnObjects.Length; i++)
		{
			Destroy(spawnObjects[i]);
		}		
		timer = GameObject.Find("TimerText");
		Destroy (timer);
	}
}
