using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour 
{
	public AudioClip hit;
	public static bool player_isDead = false;
	public int health = 7;
	public AudioClip deathSound;
    public Slider healthSlider;
	//private AudioSource source;
	mouthScript mouth;


	// Use this for initialization
	void Start () 
	{
		player_isDead = false;
        healthSlider.maxValue = health;
        healthSlider.value = health;
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
            DecreaseHP(1);
		}


		if (col.gameObject.tag == "EnemySuicide")
        {
            Debug.Log("Touched Suicide Roach");
            DecreaseHP(3);
		}
		
		if (health < 1) 
		{
			player_isDead = true;
		}

		Debug.Log ("Collided with " + col.gameObject.name);

	}

    void DecreaseHP(int amount)
    {
        health = Mathf.Max(0, health - amount);
        healthSlider.value = health;
        Debug.Log(string.Format("-{0} HP!", amount));
        Debug.Log("Health: " + health);
        AudioSource.PlayClipAtPoint(hit, transform.position);

    }
}
