using UnityEngine;
using System.Collections;

public class GotMap : MonoBehaviour {

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

			
			
			// ... the player has a key ...
			playerInventory.hasMap = true;
			playerInventory.hasMapStill = true;
			
			
			// ... and destroy this gameobject.
			Destroy(gameObject);

		}

	}
}
