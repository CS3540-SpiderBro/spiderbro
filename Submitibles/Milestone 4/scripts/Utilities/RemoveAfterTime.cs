using UnityEngine;
using System.Collections;

public class RemoveAfterTime : MonoBehaviour
{

    public float TimeToLive = 10;
	
	// Update is called once per frame
	void Update ()
	{
	    --TimeToLive;
	    if (TimeToLive < 1)
	    {
	        Destroy(gameObject);
	    }
	}
}
