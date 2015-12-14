using UnityEngine;
using System.Collections;
/// <summary>
/// move enemies towards playerTarget and delete them when collide with player
/// </summary>
/// 

[RequireComponent(typeof(AudioSource))]
public class enemyBehvaiorSuicide : MonoBehaviour 
{

    public float speed = 9.0f; // move speed
    private Vector3 target;
    public string targetTag = "Player";
   // public int damage;
    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;

	public GameObject bloodsplat;

	//for sounds
	public AudioClip deathSound;
	public AudioClip explodeSound;
	private AudioSource source;

    // Use this for initialization
    void Start () 
	{
		target = GameObject.FindGameObjectWithTag(targetTag).transform.position;
        StartCoroutine(wait());	//wait 3 seconds to fall to ground

    }

    IEnumerator wait()
    {

        yield return new WaitForSeconds(3);
          
    }
    // Update is called once per frame
    void FixedUpdate () 
	{

		if (this.gameObject.tag == "Dead") 
		{
			Debug.Log("PLAY DEATH SOUND enemyBehavior.cs");
			source.PlayOneShot (deathSound,1.0F);
			//AudioSource.PlayClipAtPoint(deathSound, transform.position);
			//stuff
		}

		findPlayer ();	//locate player's current position

		if(target != null)
        {
            Move();
        }
        
			//Debug.Log("playerTarget position" + playerTarget);
            //Debug.Log("Enemy Position" + this.gameObject.transform.position);        
        
    }

	void findPlayer()
	{
		target = GameObject.FindGameObjectWithTag(targetTag).transform.position;
	}

    void Move()	//move toward player
    {
		_direction = (target - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
    void OnTriggerEnter(Collider touched)
    {


		//spawn an explosion
		if(touched.gameObject.tag == "Player")
        {

			AudioSource.PlayClipAtPoint(explodeSound, transform.position);
			Instantiate(bloodsplat, gameObject.transform.position, gameObject.transform.rotation);

			//destroy 
			Destroy(this.gameObject);
            //Destroy(this.transform.parent.gameObject);

        }
    }
}
