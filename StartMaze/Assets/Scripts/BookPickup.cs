using UnityEngine;
using System.Collections;

public class BookPickup : MonoBehaviour {
	public AudioClip keyGrab; // Audioclip to play when the key is picked up.
	public GameObject door;
	private GameObject player;// Reference to the player.
	private PlayerInventory playerInventory;        // Reference to the player's inventory.	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		playerInventory = player.GetComponent<PlayerInventory>();
		
	}
		
	void OnTriggerEnter (Collider other)
	{
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{	
			AudioSource.PlayClipAtPoint(keyGrab, transform.position);
			playerInventory.hasBook = true;
			Destroy(gameObject);
			playerInventory.hasBookStill =true;
			
		}
	}
}
