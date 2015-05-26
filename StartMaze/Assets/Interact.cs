using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	public bool inside;
	public PlayerInventory playerInventory;        // Reference to the player's inventory.
	public AudioClip keyGrab; 
	public bool talk = false;
	private GameObject player;// Reference to the player.
	public GUIStyle style;
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player) {
			
			inside = true;
			talk = false;
		} 
		if (playerInventory.hasBookStill == true) {
			
			//playerInventory.hasBook = false;
			//playerInventory.hasBookStill = false;

			
		}
		
	}
	
	void Update(){
		
		if(Input.GetKeyDown(KeyCode.E))
		{
			talk = true;
		}
		
	}
	
	public void OnTriggerExit(Collider other) {
		
		if (other.gameObject == player) {
			
			inside = false;
			
			talk = false;


		} 


	}
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		
		playerInventory = player.GetComponent<PlayerInventory>();
	}
	
	
	public void OnGUI()
	{	
		
		if(inside == true && talk == false) {
			
			
			// Make a background box
			GUI.Box(new Rect(400,200,300,190), "Press E to interact.",style);
			
			
			
			
		}
		else if(inside == true && talk == true)
		{

			if ((playerInventory.hasBookStill == false) && (playerInventory.hasKeyGreen == false)) {
				GUI.Box(new Rect(100,100,1000,1000), "My brother went through the door with the blue\n  marking to try to find a map that's rumoured to \nbe inside. He's been gone for 2 days now,\n Will you look for him?", style);

			} else if (playerInventory.hasBookStill == true){
				//playerInventory.hasBook = false;
				GUI.Box(new Rect(100,100,1000,1000), "That's his spell book!! That must mean my brother is \n ... ugh... here, take this Green key. I have no usefor it now.", style);

				playerInventory.hasKeyGreen = true;
				playerInventory.greenKeyUp =true;
				//AudioSource.PlayClipAtPoint(keyGrab, transform.position);	


			}




		}
		
		
		//playerInventory.hasBookStill = false;
	}
}
