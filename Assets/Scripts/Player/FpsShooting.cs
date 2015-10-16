using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class FpsShooting : MonoBehaviour {
	public Rigidbody bullet;
	private float bulletforce = 100.0f;

    public Slider spitSlider;
    public float SPIT_CAPACITY = 3f;
    public float SPIT_REGEN_RATE = 1f;

    private float spitAmmo;

	public AudioClip fireProjectile;
	private AudioSource source;

	// Use this for initialization
	void Start () 
	{
		//init audio source
		source = GetComponent<AudioSource>();

        spitAmmo = SPIT_CAPACITY;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        spitAmmo = Mathf.Min(SPIT_CAPACITY, spitAmmo + SPIT_REGEN_RATE * Time.deltaTime);

		if (Input.GetButtonDown("Fire2") && spitAmmo >= 1f)
		{
			source.PlayOneShot (fireProjectile, 1.0F);

			Camera cam = Camera.main;
			Rigidbody projectile = (Rigidbody)Instantiate (bullet, cam.transform.position + cam.transform.forward, cam.transform.rotation);
			projectile.AddForce(cam.transform.forward * bulletforce, ForceMode.Impulse);
            spitAmmo -= 1f;
		}

        spitSlider.value = spitAmmo / SPIT_CAPACITY;
	}
}
