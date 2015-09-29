using UnityEngine;
using System.Collections;

public class FpsShooting : MonoBehaviour {
	public Rigidbody bullet;
	private float bulletforce = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Fire2")){
			Camera cam = Camera.main;
			Rigidbody projectile = (Rigidbody)Instantiate (bullet, cam.transform.position + cam.transform.forward, cam.transform.rotation);
			projectile.AddForce(cam.transform.forward * bulletforce, ForceMode.Impulse);
		}
	}
}
