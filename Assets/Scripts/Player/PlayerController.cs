using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 6f;

	private Rigidbody rb;

	void Start (){
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		movement = movement * speed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);

	}
}
