using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts.Player;

[RequireComponent(typeof(AudioSource))]
public class BulletBehaviour : MonoBehaviour {

	public float lifespan = 3.0f;
	public GameObject explode;
	public LevelStatus levelStatus;

    public GameObject bloodsplat;
    public GameObject Bulletsplat;

	//public AudioClip deathSound;
	//private AudioSource source;

    // Use this for initialization
    void Start () 
	{
		//init audio source
		//source = GetComponent<AudioSource>();

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
	void FixedUpdate () 
	{
		if ((lifespan -= Time.deltaTime) <= 0) 
		{
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
        else if(col.gameObject.CompareTag("DeadReady"))
        {
            try
            {

                KillEnemy(col);
                levelStatus.AddKill();
                Debug.Log("Killing queen");

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        Debug.Log(col.gameObject.tag);
        Destroy(gameObject);
    }

    void Disappear ()
	{
		Destroy (gameObject);
	}

	void KillEnemy(Collision col)
	{
		//source.PlayOneShot (deathSound,1.0F);
		col.gameObject.tag = "Dead";
		Instantiate(bloodsplat, gameObject.transform.position, gameObject.transform.rotation);

        Destroy(col.gameObject);
        Destroy(col.transform.parent.gameObject);
    }
}
