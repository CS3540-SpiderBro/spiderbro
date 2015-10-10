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
        
    }
	
	// Update is called once per frame
	void Update () {
        mbj = GameObject.FindGameObjectWithTag(targetTag);
        
        // move towards motherbase
        if (mbj != null)
        {
            motherbase = GameObject.FindGameObjectWithTag(targetTag).transform.position;
            transform.position = Vector3.MoveTowards(transform.position, motherbase, speed);
        }
        
    }


    void OnCollisionEnter(Collision touched)
    {
       
        if (touched.gameObject.tag == modelTag)
        {
            
            Destroy(this.gameObject);            
           
        }
    }
}
