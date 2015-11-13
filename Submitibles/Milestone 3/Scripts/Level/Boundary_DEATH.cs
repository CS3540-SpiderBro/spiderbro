using UnityEngine;
using System.Collections;

public class Boundary_DEATH : MonoBehaviour {

	public string level = "GregTest2";

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			Destroy (other.gameObject);
			Application.LoadLevel (level);
		}

	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
