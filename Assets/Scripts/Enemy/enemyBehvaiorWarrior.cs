using UnityEngine;
using System.Collections;
/// <summary>
/// Flies toward player and then stops and fires a shot once in range
/// </summary>
/// 

[RequireComponent(typeof(AudioSource))]
public class enemyBehvaiorWarrior : MonoBehaviour {

    public float speed = 9.0f; // move speed
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
        StartCoroutine(wait());

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
			//stuff
		}

		if(playerTarget != null)
        {
            Move();
        }
        
			//Debug.Log("playerTarget position" + playerTarget);
            //Debug.Log("Enemy Position" + this.gameObject.transform.position);        
        
    }

    void Move()
    {
		_direction = (playerTarget - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		transform.position = Vector3.MoveTowards(transform.position, playerTarget, speed);
    }
    void OnCollisionEnter(Collision touched)
    {
       //if 
        if (touched.gameObject.tag == damagerTag)
        {
            
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
			Instantiate(deathSound, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);

        }
    }
}
