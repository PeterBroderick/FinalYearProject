using UnityEngine;
using System.Collections;

public class MazeDoorScript : MonoBehaviour {

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
		light = GameObject.Find ("DoorMasterGreen/GreenDoorOpen/Point light");
		playerInventory = player.GetComponent<PlayerInventory>();
		door = GameObject.Find ("DoorMasterGreen/GreenDoorOpen/Cube");
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {

			if (playerInventory.hasKeyGreen == false) {
				
				AudioSource.PlayClipAtPoint (accessDenied, transform.position);
				
				
			} else {
				AudioSource.PlayClipAtPoint (doorOpen, transform.position);

				Destroy (door);

			}
		}
		
	}
}
