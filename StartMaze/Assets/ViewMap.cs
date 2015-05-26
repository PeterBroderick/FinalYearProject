using UnityEngine;
using System.Collections;

public class ViewMap : MonoBehaviour {
	
	private PlayerInventory playerInventory; 
	public bool viewMap = false;
	public GameObject player;
	public Texture2D images;
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		playerInventory = player.GetComponent<PlayerInventory>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.M)) 
		{

			viewMap = true;
		} 
		else if (Input.GetKeyUp (KeyCode.M))
		{
			viewMap = false;
		}
	}
	
	void OnGUI()
	{	
		if (playerInventory.hasMap == true && viewMap == true) {
			GUI.Label(new Rect(10, 40, images.width, 600), images);
			
		} 
		else if (playerInventory.hasMap == false && viewMap == true) {
			//GUI.Box (new Rect (10,10,100,50), new GUIContent("This is a Map", images));
			GUI.Box (new Rect (400, 200, 300, 190), "You do not have a map!!");
			//GUI.Box (new Rect (400, 200, 300, 190), " No Map!!");
		} 
		else if (viewMap == false) 
		{
			
		}
		
	}
}
