using UnityEngine;
using System.Collections;
[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {
	public float movementSpeed = 6.0f;
	public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;
	public float rotUpDown = 0;
	public float upDownRange = 60.0f;
	float verticalVelovicty = 0; 
	CharacterController characterController;
	private PlayerInventory playerInventory;

	void Start(){
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController characterController = GetComponent<CharacterController>();
		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);

		rotUpDown -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rotUpDown = Mathf.Clamp (rotUpDown, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (rotUpDown, 0,0);

		float forwardSpeed = Input.GetAxis("Vertical")*movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal")*movementSpeed;

		verticalVelovicty += Physics.gravity.y * Time.deltaTime;

		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalVelovicty = jumpSpeed;

			forwardSpeed = (Input.GetAxis("Vertical")*movementSpeed)/2;
			sideSpeed = (Input.GetAxis("Horizontal")*movementSpeed)/2;
		}

		Vector3 speed = new Vector3 (sideSpeed,verticalVelovicty,forwardSpeed);

		speed = transform.rotation * speed;

		//C

		characterController.Move(speed*Time.deltaTime);


	}


}
