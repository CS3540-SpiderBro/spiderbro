using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour 
{
	public AudioClip hit;
	public static bool player_isDead = false;
	public int health = 7;
	public int projectileDmg = 1;
	public int suicideDmg = 3;
	public AudioClip deathSound;
    public Slider healthSlider;
	//private AudioSource source;
	mouthScript mouth;


	// Use this for initialization
	void Start () 
	{
		health = 7;
		suicideDmg = 3;
		projectileDmg = 1;
		player_isDead = false;
        healthSlider.maxValue = health;
        healthSlider.value = health;
		this.gameObject.SetActive (true);
    }
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (player_isDead) 	//this doesn't really work
		{
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
			this.gameObject.SetActive(false);
			//Destroy(this.gameObject);
		}
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("bullet"))
		{
			DecreaseHP(projectileDmg);
		}


		if (col.gameObject.tag == "EnemySuicide")
        {
            Debug.Log("Touched Suicide Roach");
			DecreaseHP(suicideDmg);
		}
		
		if (health < 1) 
		{
			player_isDead = true;
		}

        Debug.Log("Collided with " + col.gameObject.name);
        Debug.Log("Tagged with " + col.gameObject.tag);

    }

    void DecreaseHP(int amount)
    {
		if (health < 0)	//if we're already past 0
			return;

        //health = Mathf.Max(0, health - amount);
		health = health - amount;
        healthSlider.value = health;
        Debug.Log(string.Format("-{0} HP!", amount));
        Debug.Log("Health: " + health);
        AudioSource.PlayClipAtPoint(hit, transform.position);

    }
}
