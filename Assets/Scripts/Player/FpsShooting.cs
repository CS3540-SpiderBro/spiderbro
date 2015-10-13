using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FpsShooting : MonoBehaviour {
	public Rigidbody bullet;
	private float bulletforce = 100.0f;

    public Slider spitSlider;
    public float SPIT_CAPACITY = 3f;
    public float SPIT_REGEN_RATE = 1f;

    private float spitAmmo;

	// Use this for initialization
	void Start () 
	{
        spitAmmo = SPIT_CAPACITY;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        spitAmmo = Mathf.Min(SPIT_CAPACITY, spitAmmo + SPIT_REGEN_RATE * Time.deltaTime);

		if (Input.GetButtonDown("Fire2") && spitAmmo >= 1f){
			Camera cam = Camera.main;
			Rigidbody projectile = (Rigidbody)Instantiate (bullet, cam.transform.position + cam.transform.forward, cam.transform.rotation);
			projectile.AddForce(cam.transform.forward * bulletforce, ForceMode.Impulse);
            spitAmmo -= 1f;
		}

        spitSlider.value = spitAmmo / SPIT_CAPACITY;
	}
}
