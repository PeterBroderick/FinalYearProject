using UnityEngine;
using System.Collections;

public class Sign : MonoBehaviour {

	public bool inside;
	private GameObject player;
	private PlayerInventory playerInventory;        // Reference to the player's inventory.
	public GUIStyle style;
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInventory = player.GetComponent<PlayerInventory>();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {

			inside = true;


		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player) {
			
			inside = false;
			
		}
		
	}

	

	private void OnGUI()
	{
				if (inside == true) {
						GUI.Box (new Rect (Screen.width - 800, 200, 400, 200), "\n\n\nWelcome, you need to escape from\n the courtyard through the maze.\n you will need the BLUE key first.",style);

				}
		}
}
