using UnityEngine;
using System.Collections;
/// <summary>
/// move enemies towards motherbase and delete them when collide with base
/// </summary>
public class enemyBehvaior : MonoBehaviour {

    public float speed = 5.0f; // move speed
    Vector3 motherbase;
    GameObject mbj;
    public string targetTag;
    public string modelTag;
    public int damage;

    // Use this for initialization
    void Start () {
        motherbase = GameObject.FindGameObjectWithTag(targetTag).transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
           
            transform.position = Vector3.MoveTowards(transform.position, motherbase, speed);
            //Debug.Log("MOtherbase position" + motherbase);
            //Debug.Log("Enemy Position" + this.gameObject.transform.position);        
        
    }


    void OnCollisionEnter(Collision touched)
    {
       
        if (touched.gameObject.tag == modelTag)
        {
            
            Destroy(this.gameObject);            
           
        }
    }
}
