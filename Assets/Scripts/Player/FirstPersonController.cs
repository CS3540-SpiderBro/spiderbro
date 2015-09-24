using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float upDownRange = 60.0f;
	public float jumpSpeed = 5.0f;
	
	private float verticalRotation = 0.0f;
	private CharacterController characterController;
	
	private float vertVelocity = 0;
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		RotateLeftRight ();
		RotateUpDown ();
		Movement ();
	}
	
	void Movement ()
	{
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		vertVelocity += Physics.gravity.y * Time.deltaTime;
		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			vertVelocity = jumpSpeed;
		}
		Vector3 speed = new Vector3 (sideSpeed, vertVelocity, forwardSpeed);
		speed = transform.rotation * speed;
		characterController.Move (speed * Time.deltaTime);
	}
	
	static void HideMouse ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	void RotateLeftRight ()
	{
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);
	}
	
	void RotateUpDown ()
	{
		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
	}
}
