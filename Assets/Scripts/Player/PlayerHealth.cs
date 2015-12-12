using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour 
{
	public static bool player_isDead = false;
	public int health = 7;
	public AudioClip deathSound;
	//private AudioSource source;


	// Use this for initialization
	void Start () 
	{
		player_isDead = false;
		health = 7;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (player_isDead) 
		{
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
			this.gameObject.SetActive(false);
		}
	
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("bullet"))
		{
			health--;
			Debug.Log("-1 HP!");
		}


		if (col.gameObject.name == "SuicideRoach" || col.gameObject.name == "redRoach") 
		{
			Debug.Log ("Touched Suicide Roach");
			health = health - 3;
			Debug.Log ("-3 HP!");
		}
		
		if (health >= 0) 
		{
			gameObject.tag = "DeadReady";
		}

		Debug.Log ("Collided with " + col.gameObject.name);

	}
}
