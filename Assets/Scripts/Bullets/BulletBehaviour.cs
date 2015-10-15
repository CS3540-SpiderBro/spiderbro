using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class BulletBehaviour : MonoBehaviour {

	public float lifespan = 3.0f;
	public GameObject explode;
	public LevelStatus levelStatus;

    public GameObject bloodsplat;
    public GameObject Bulletsplat;

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
		Instantiate(Bulletsplat, gameObject.transform.position, gameObject.transform.rotation);
        if (col.gameObject.CompareTag ("Enemy")) {
			try{

				KillEnemy(col);
				levelStatus.AddKill();


			}
			catch (Exception e){
				Debug.Log(e.Message);
			}

		}
        Destroy(gameObject);
    }

    void Disappear ()
	{
		Destroy (gameObject);
	}

	void KillEnemy(Collision col){
		col.gameObject.tag = "Dead";
		Instantiate(bloodsplat, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(col.gameObject);
        Destroy(col.transform.parent.gameObject);
    }
}
