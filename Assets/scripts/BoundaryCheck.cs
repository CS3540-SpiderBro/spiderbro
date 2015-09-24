using UnityEngine;
using System.Collections;

public class BoundaryCheck : MonoBehaviour 
{
	public bool player_isDead = false;

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			player_isDead = true;
			Destroy (other.gameObject);
			OnGUI ();
		}
	}

	void OnGUI() 
	{
		if (player_isDead) 
		{
			GUI.Box (new Rect ((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), "You have died.\n\nPress backspace to restart.");
		}
	}

}
