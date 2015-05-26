using UnityEngine;
using System.Collections;

public class ShootingFPS : MonoBehaviour {

	// Use this for initialization
	public GameObject bullet_prefab;
	public GameObject grenade_prefab;
	float bulletSpeed = 100f;
	public AudioClip throwGrenade;
	public GameObject smoke;

	void Start()
	{


	}

	void Update () {
		//gun_prefab = null;
		Camera c = Camera.main;

		if (Input.GetButtonDown ("Fire1")) {
			GameObject fpsGrenade= (GameObject)Instantiate (grenade_prefab, c.transform.position, c.transform.rotation);
			fpsGrenade.rigidbody.AddForce(c.transform.forward * bulletSpeed, ForceMode.Impulse);
			//fire.rigidbody.AddForce(c.transform.forward * bulletSpeed, ForceMode.Impulse);
			AudioSource.PlayClipAtPoint (throwGrenade, transform.position);
			//Screen.lockCursor = true;
		}
		else if (Input.GetButtonDown ("Fire2")) {

			Screen.lockCursor = true;

		}

		else if (Input.GetButtonDown ("F")) {
			Instantiate(smoke,  transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint (throwGrenade, transform.position);
			
		}
	}
}
