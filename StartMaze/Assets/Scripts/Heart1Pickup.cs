using UnityEngine;
using System.Collections;

public class Heart1Pickup : MonoBehaviour {

	public AudioClip keyGrab; // Audioclip to play when the key is picked up.
	
	public GameObject door;
	private GameObject player;// Reference to the player.
	//private GameObject doorM;// Reference to the player.
	private PlayerInventory playerInventory;        // Reference to the player's inventory.
	private ItemDatabase database;
	private Inventory inventory; 
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerInventory = player.GetComponent<PlayerInventory>();
	}
	
	void OnTriggerEnter (Collider other)
	{	
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			// ... play the clip at the position of the key...
			AudioSource.PlayClipAtPoint(keyGrab, transform.position);
			
		
			Destroy(gameObject);

			playerInventory.hasHeart1 =true;
			
			
		}
	}
}
