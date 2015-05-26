using UnityEngine;
using System.Collections;

public class DoorOpenerBlue : MonoBehaviour {

	public AudioClip doorOpen;
	public AudioClip accessDenied;
	public GameObject light;
	public GameObject door;
	private GameObject player;// Reference to the player.
	private PlayerInventory playerInventory;        // Reference to the player's inventory.

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		light = GameObject.Find ("DoorMasterBlue/BlueDoorOpen/Point light");
		playerInventory = player.GetComponent<PlayerInventory>();
		door = GameObject.Find ("DoorMasterBlue/BlueDoorOpen/Cube");
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {		
			// If the colliding gameobject is the player...
			if (playerInventory.hasKeyBlue == false) {			
				AudioSource.PlayClipAtPoint (accessDenied, transform.position);			
			} else {
				AudioSource.PlayClipAtPoint (doorOpen, transform.position);		
				Destroy (door);
				Destroy (light);

			}
		}
		
	}
}
