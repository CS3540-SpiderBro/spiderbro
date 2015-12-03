using UnityEngine;
using System.Collections;
using UnityEditor;

public class FlyingQueenBehavior : MonoBehaviour
{

    public Transform[] waypoints;
    public float speed;
    public int curWaypoint;
    public bool doPatrol = true;
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var rb = GetComponent<Rigidbody>();
        if (curWaypoint < waypoints.Length)
	    {
	        Target = waypoints[curWaypoint].position;
	        MoveDirection = Target - transform.position;
	        Velocity = rb.position;

	        if (MoveDirection.magnitude < 1)
	        {
	            curWaypoint++;
	        }
	        else
	        {
	            Velocity = MoveDirection.normalized*speed;
	        }
	    }
	    else
	    {
	        if (doPatrol)
	        {
	            curWaypoint = 0;
	        }
	        else
	        {
	            Velocity = Vector3.zero;
	        }
	    }

	    rb.velocity = Velocity;
        transform.LookAt(Target);
	}
}
