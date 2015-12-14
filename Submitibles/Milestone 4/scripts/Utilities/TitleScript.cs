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
			Application.LoadLevel("Wave1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) Application.LoadLevel("Wave1");
        if (Input.GetKeyDown(KeyCode.Alpha2)) Application.LoadLevel("Wave2");
        if (Input.GetKeyDown(KeyCode.Alpha3)) Application.LoadLevel("Wave3");
        if (Input.GetKeyDown(KeyCode.Alpha4)) Application.LoadLevel("Wave4");
        if (Input.GetKeyDown(KeyCode.Alpha5)) Application.LoadLevel("Wave5");

        if (Input.GetKeyDown (KeyCode.F12)) 
		{
			Screen.fullScreen = true;
		}
	}
}
