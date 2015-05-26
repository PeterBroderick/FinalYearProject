using UnityEngine;
using System.Collections;

public class KeyPickUp : MonoBehaviour {
	
	public AudioClip keyGrab; // Audioclip to play when the key is picked up.
	
	public GameObject door;
	private GameObject player;// Reference to the player.
	//private GameObject doorM;// Reference to the player.
	private PlayerInventory playerInventory;        // Reference to the player's inventory.
	private ItemDatabase database;
	private Inventory inventory; 

	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		playerInventory = player.GetComponent<PlayerInventory>();
		//doorM = GameObject.FindGameObjectWithTag("Door Master");

	}
	
	
	void OnTriggerEnter (Collider other)
	{	
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			// ... play the clip at the position of the key...
			AudioSource.PlayClipAtPoint(keyGrab, transform.position);
			
			
			// ... the player has a key ...
			playerInventory.hasKey = true;

			// ... and destroy this gameobject.
			Destroy(gameObject);
			
			
			playerInventory.redKeyUp =true;

			
		}
	}
}