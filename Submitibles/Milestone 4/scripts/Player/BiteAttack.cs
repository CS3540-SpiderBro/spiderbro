using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;

[RequireComponent(typeof(AudioSource))]
public class BiteAttack : MonoBehaviour 
{
	public AudioClip biteSound;
	public AudioClip attemptBite;
	private AudioSource source;

	public GameObject bloodsplat;
	public LevelStatus levelStatus;
	private Collider myEnemy;
	private bool enemy_in_range = false;



	//possibly use this later
	/*public float BITE_REGEN_RATE = 0.5f;
	private float biteAmmo;
	public float BITE_CAPACITY = 1f;*/

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemySuicide") 
		{
			enemy_in_range = true;
			myEnemy = other;
		} 

		else
			enemy_in_range = false;

	}

	void KillEnemy(Collider col)
	{
		source.PlayOneShot (biteSound, 1.0F); //play collision attack sound
		col.gameObject.tag = "Dead";
		Instantiate(bloodsplat, gameObject.transform.position, gameObject.transform.rotation);
		Destroy(col.gameObject);
        Destroy(col.transform.parent.gameObject);
    }


	// Use this for initialization
	void Start () 
	{
		//init audio source
		source = GetComponent<AudioSource>();

		//why is this even here?
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
		/*biteAmmo = Mathf.Min(BITE_CAPACITY, biteAmmo + BITE_REGEN_RATE * Time.deltaTime);*/

		//if(Input.GetButtonDown("Fire1") /*&& biteAmmo >= 0.25f*/)
			//source.PlayOneShot (attemptBite, 1.0F);

		if (Input.GetButtonDown ("Fire1")) 
		{
			source.PlayOneShot (attemptBite, 1.0F);	//attempted fire

			if(enemy_in_range == true)
			{


				//broken to be fixed later maybe
				/*EnemyStats.hp += -50;	//do 50 dmg
				Debug.Log ("50 dmg!");*/

				try
				{
					KillEnemy (myEnemy);
					levelStatus.AddKill();
				}

				catch
				{
					Debug.Log ("Problem killing enemy!");
				}

			}

		}

	}//fixedupdate()
}
