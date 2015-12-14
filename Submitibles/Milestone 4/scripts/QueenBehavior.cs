using UnityEngine;
using System.Collections;

public class QueenBehavior : MonoBehaviour
{
    public int DamagePoint;
    private EnemyStats stats;
	// Use this for initialization
	void Start ()
	{
	    stats = GetComponent<EnemyStats>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            stats.xp -= DamagePoint;
            Debug.Log("Hit: " +  stats.xp);
        }

		/* FIX ME Later
		if (col.gameObject.CompareTag ("playerBite")) 
		{
			stats.xp -= DamagePoint * 3;
			Debug.Log ("Hit: " + stats.xp);
		}*/

        if (stats.xp <= DamagePoint) gameObject.tag = "DeadReady";
    }
}
