using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class BulletBehaviour : MonoBehaviour {

	public float lifespan = 3.0f;
	public GameObject explode;
	public LevelStatus levelStatus;



	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			levelStatus = gameControllerObject.GetComponent<LevelStatus>();	
		}

		if (levelStatus == null)
		{
			Debug.Log ("Cannot find levelStatus from game controller");
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ((lifespan -= Time.deltaTime) <= 0) {
			Disappear ();
		}

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Enemy")) {
			try{

				KillEnemy(col);
				levelStatus.AddKill();
//				EnemyCount -= 1;
//				killCount += 1;


			}
			catch (Exception e){
				Debug.Log(e.Message);
			}

		}
	}

	void Disappear ()
	{
		Destroy (gameObject);
	}

	void KillEnemy(Collision col){
		Destroy(gameObject);
		col.gameObject.tag = "Dead";
		Instantiate(explode, col.gameObject.transform.position, Quaternion.identity);
		Destroy (col.gameObject);
	}
}
