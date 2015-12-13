using UnityEngine;
using System.Collections;

public class LogoScript : MonoBehaviour 
{
	public string level = "Title";


	void Start () 
	{
		ModeSelect ();
	}

		
		
	public void  ModeSelect()
	{
			StartCoroutine(LoadAfterDelay(level));
	}
		
	IEnumerator LoadAfterDelay(string levelName)
	{
			yield return new WaitForSeconds(05); // wait 1 seconds
			Application.LoadLevel(levelName);
			
	}

	
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
