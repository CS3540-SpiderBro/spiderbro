using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour 
{
	public string level = "Title";

		
		// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) ) 
        {
			Application.LoadLevel(level);
        }

		if (Input.GetKeyDown (KeyCode.F12)) 
		{
			Screen.fullScreen = true;
		}
	}
}
