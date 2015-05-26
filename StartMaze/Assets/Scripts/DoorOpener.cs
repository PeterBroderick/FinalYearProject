using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DoorOpener : MonoBehaviour {

	public AudioClip doorOpen;
	public AudioClip accessDenied;
	public GameObject door;
	public GameObject light;
	private GameObject player;// Reference to the player.
	private PlayerInventory playerInventory;        // Reference to the player's inventory.
	private ItemDatabase itemdb;
	public List<Item> items = new List<Item>();
	private Inventory inventory; 

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		light = GameObject.Find ("DoorMaster/Point light");
		playerInventory = player.GetComponent<PlayerInventory>();
		door = GameObject.Find ("DoorMaster/RedDoorOpen/Cube");
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {
			
			// If the colliding gameobject is the player...
			if (playerInventory.hasKey == false) {			
				AudioSource.PlayClipAtPoint (accessDenied, transform.position);			
				
			} else {
				AudioSource.PlayClipAtPoint (doorOpen, transform.position);
				Destroy (door);
				Destroy(light);

			}
		}
		
	}
}