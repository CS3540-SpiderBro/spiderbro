using UnityEngine;
using System.Collections;

public class LogoScript : MonoBehaviour 
{
	public string level = "Title";

	/*
	void Start () 
	{
		StartCoroutine (wait ());	//wait 4 seconds to fall to ground
		Application.LoadLevel (level);
	}
	
	IEnumerator wait()
	{
		
		yield return new WaitForSeconds (4.0f);
	}*/

	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("space") ) 
        {
			Application.LoadLevel(level);
        }

		if (Input.GetKeyDown ("f12")) 
		{
			Screen.fullScreen = true;
		}
	}
}
