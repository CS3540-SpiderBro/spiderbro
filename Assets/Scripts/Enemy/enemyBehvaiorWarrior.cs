using UnityEngine;
using System.Collections;
/// <summary>
/// Flies toward player and then stops and fires a shot once in range
/// </summary>
/// 

[RequireComponent(typeof(AudioSource))]
public class enemyBehvaiorWarrior : MonoBehaviour {

    public float speed = 0.2f; // move speed
	public float mindist = 8.0f;
    Vector3 playerTarget;
    //GameObject mbj;
    public string targetTag;
    public string damagerTag;
   // public int damage;
    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;

	//for sounds
	public AudioClip deathSound;
	private AudioSource source;

    // Use this for initialization
    void Start () 
	{
		playerTarget = GameObject.FindGameObjectWithTag(targetTag).transform.position;
		StartCoroutine(LoadAfterDelay());

    }

	IEnumerator LoadAfterDelay()
	{
		yield return new WaitForSeconds(05); // wait 1 seconds
	}
    // Update is called once per frame
    void FixedUpdate () 
	{

		if (this.gameObject.tag == "Dead") 
		{
			Debug.Log("PLAY DEATH SOUND enemyBehavior.cs");
			source.PlayOneShot (deathSound,1.0F);
			//stuff
		}

		findPlayer ();	//locate player's current position

		if(playerTarget != null)
        {
            Move();
        }
        
			//Debug.Log("playerTarget position" + playerTarget);
            //Debug.Log("Enemy Position" + this.gameObject.transform.position);        
        
    }

	void findPlayer()
	{
		playerTarget = GameObject.FindGameObjectWithTag(targetTag).transform.position;
	}

    void Move()
    {
		_direction = (playerTarget - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);


		float distance = Vector3.Distance (transform.position, playerTarget);	//find distance between us and player
		Debug.Log ("Distance is: " + distance);
		if (distance > mindist) 
		{
			transform.position = Vector3.MoveTowards (transform.position, playerTarget, speed);
		}	//if we're further away from player than mindist, get closer
    }
    void OnCollisionEnter(Collision touched)
    {
       //if we get hit by projectile, time to explode
        if (touched.gameObject.tag == damagerTag)
        {
            
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
			Instantiate(deathSound, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);

        }
    }
}
