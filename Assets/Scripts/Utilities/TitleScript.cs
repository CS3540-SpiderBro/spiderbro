using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour 
{
	public string level = "Title";

		
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
