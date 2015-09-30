using UnityEngine;
using System.Collections;
/// <summary>
/// move enemies towards motherbase and delete them when collide with base
/// </summary>
public class enemyBehvaior : MonoBehaviour {

    public float speed = 5.0f; // move speed
    public Transform motherbase;
    public GameObject mbj;
    public int damage;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        mbj = GameObject.FindGameObjectWithTag("MotherBase");
        // move towards motherbase
        if (mbj != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, motherbase.position, speed);
        }
        
    }


    void OnCollisionEnter(Collision touched)
    {
       
        if (touched.gameObject.tag == "MotherBase")
        {
            
            Destroy(this.gameObject);            
           
        }
    }
}
