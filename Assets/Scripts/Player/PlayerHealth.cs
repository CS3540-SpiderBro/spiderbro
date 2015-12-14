using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour 
{
	public AudioClip hit;
	public static bool player_isDead = false;
	public int health = 7;
	public AudioClip deathSound;
	//private AudioSource source;
	mouthScript mouth;


	// Use this for initialization
	void Start () 
	{
		player_isDead = false;
		health = 7;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (player_isDead) 	//this doesn't really work
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
			AudioSource.PlayClipAtPoint(hit, transform.position);
		}


		if (col.gameObject.tag == "EnemySuicide") 
		{
			Debug.Log ("Touched Suicide Roach");
			health = health - 3;
			AudioSource.PlayClipAtPoint(hit, transform.position);
			Debug.Log ("-3 HP!");
			Debug.Log ("Health: " + health);
		}
		
		if (health < 1) 
		{
			player_isDead = true;
		}

		Debug.Log ("Collided with " + col.gameObject.name);

	}
}
