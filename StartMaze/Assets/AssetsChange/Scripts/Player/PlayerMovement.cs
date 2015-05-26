using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float movementSpeed = 6.0f;

	public float speed = 6f;
	public float mouseSensitivity = 5.0f;
	float rotUpDown = 0;
	public float upDownRange = 60.0f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	void Awake()
	{

		floorMask = LayerMask.GetMask("Floor");	
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();

	}
	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		/*
		Move (h,v);

		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);
		
		rotUpDown -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rotUpDown = Mathf.Clamp (rotUpDown, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (rotUpDown, 0,0);
		Turning ();
		Animating (h, v);*/

		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);
		
		rotUpDown -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rotUpDown = Mathf.Clamp (rotUpDown, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (rotUpDown, 0,0);
		
		float forwardSpeed = Input.GetAxis("Vertical")*movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal")*movementSpeed;
		
		Vector3 speed = new Vector3 (sideSpeed,0,forwardSpeed);
		
		speed = transform.rotation * speed;
		
		CharacterController cc = GetComponent<CharacterController>();
		
		cc.SimpleMove(speed);
		Turning ();

		Move (h,v);

	}
	/*void Update () {

		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);
		
		rotUpDown -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		rotUpDown = Mathf.Clamp (rotUpDown, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (rotUpDown, 0,0);
		
		float forwardSpeed = Input.GetAxis("Vertical")*movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal")*movementSpeed;
		
		Vector3 speed = new Vector3 (sideSpeed,0,forwardSpeed);
		
		speed = transform.rotation * speed;
		
		CharacterController cc = GetComponent<CharacterController>();
		
		cc.SimpleMove(speed);
		//Turning ();
		
		
	}*/
	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);

	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y= 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);


		}


	}
	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}


}
