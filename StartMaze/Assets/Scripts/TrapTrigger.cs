using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	public GameObject cubeDisappear;
	public GameObject cube;
	private GameObject player;
	public AudioClip BoulderSound;

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		cubeDisappear = GameObject.Find("CubeToDisappear");
		cube = GameObject.Find("CubeTrigger");

	}

	void OnTriggerEnter (Collider other)
	{
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			// ... play the clip at the position of the key...
		
			AudioSource.PlayClipAtPoint(BoulderSound, transform.position);
			
			
			// ... and destroy this gameobject.
			Destroy(cube);
			Destroy(cubeDisappear);
			
			
		}
	}
}
