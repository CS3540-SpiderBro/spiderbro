using UnityEngine;
using System.Collections;

public class Boundary_ENEMYDEATH : MonoBehaviour {


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);            
        }

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
