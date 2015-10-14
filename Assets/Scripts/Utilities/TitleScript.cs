using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	public string level = "GregTest2";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") ) 
        {
			Application.LoadLevel(level);
        }
	}
}
