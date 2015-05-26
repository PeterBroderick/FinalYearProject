using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	private KeyPickUp keyPickup;
	public PlayerHealth playerHealth;
	public List<Item> inventory = new List<Item>();
	private ItemDatabase database;
	public List<Item> slots = new List<Item>();
	private bool showInventory;
	private bool showTooltip;
	private string tooltip;
	private PlayerInventory playerInventory;
	private GameObject player;
	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;
	public Transform prefab;
	public GameObject cube;

	void Awake ()
	{

		player = GameObject.FindGameObjectWithTag("Player");

		// Setting up the references.
		playerInventory = player.GetComponent<PlayerInventory>();
		//doorM = GameObject.FindGameObjectWithTag("Door Master");
		
	}
	// Use this for initialization
	void Start () {
		
		for(int i=0; i< (slotsX * slotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		//inventory.Add ();
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();


		//print(database.items[0].itemName);
		//print(database.items[1].itemName);
		//print (inventory.Count);
		//inventory.Add (database.items[0]);
		//inventory.Add (database.items [1]);
		//print (inventory[0].itemName);
		//inventory[0] = database.items[0];
		//inventory[1] = database.items[1];
		//AddItem (0);
		//AddItem (1);
		//AddItem (1);
		//AddItem (3);

		//AddItem (0);
	}
	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			if (playerInventory.blueKeyUp == false) {
				
			} else if (playerInventory.blueKeyUp == true){
				AddItem (0);
			}
			if (playerInventory.redKeyUp == false) {
				
			} else if (playerInventory.redKeyUp == true){
				AddItem (2);
			}
			if (playerInventory.hasHeart1 == false) {
				
			} else if (playerInventory.hasHeart1 == true){
				AddItem (3);
			}
			
			
			if (playerInventory.hasBook == false) {
				
			} 
			else if (playerInventory.hasBook == true){
				
				AddItem (5);		
			}
			
			
			if (playerInventory.greenKeyUp == false) {
				
			} else if (playerInventory.greenKeyUp == true){
				AddItem (4);
				
			}
			
			if (playerInventory.hasMapStill == false) {
				
			} else if (playerInventory.hasMapStill == true){
				AddItem (6);
				
			}
			//if you leave the interact is true then check to see 
			
			
			
			
			
			showInventory =! showInventory;
			//else {
			//}
			playerInventory.redKeyUp = false;
			playerInventory.blueKeyUp = false;
			playerInventory.hasHeart1 = false;
			playerInventory.greenKeyUp = false;
			playerInventory.hasBook = false;
			playerInventory.hasMapStill  = false;
			
		}


	}


	Vector3 GeneratedPosition()
	{
		int x,y,z;
		x = 1110;
		y = 2;
		z = 1054;
		return new Vector3(x,y,z);
	}

	void PlaceCubes()
	{
		Instantiate(cube, GeneratedPosition(), Quaternion.identity);

	}

	void OnGUI()
	{
		tooltip = "";

		GUI.skin = skin;
		if(showInventory)
		{
			DrawInventory();
			if(showTooltip)
			
				GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));

		}

		if (draggingItem) {
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 100, 100), draggedItem.itemIcon);

				}		

		//for (int i = 0; i < inventory.Count; i++) 
		//{
		//	GUI.Label (new Rect(10,i*20,200,50), inventory[i].itemName);
		//}
	}

	void DrawInventory()
	{


		Event e = Event.current;

		int i = 0;
		for(int y=0; y < slotsY; y++){
				for(int x = 0; x < slotsX; x++){
			
				Rect slotRect = new Rect(x*125, y*125,100,100);
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if(slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect, slots[i].itemIcon);

					if(slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;
						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{

							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();

						}

						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}

						if(e.type == EventType.mouseDown && !draggingItem)
						{
							//RemoveItem (0);
							playerInventory.hasHeart1 = false;
							Update();
						}
					}



				} else{

					if(slotRect.Contains(e.mousePosition))
					{
						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}


					}
				}


				if(tooltip == "")
				{
					showTooltip = false;
				}



				i++;

			}

		}


	}

	string CreateTooltip(Item item)
	{

		tooltip = "<color=#ffffff>"+ item.itemName + "</color>\n\n" + item.itemDesc;
		return tooltip;
	}

	void AddItem(int id) 
	{
		for (int i=0; i < inventory.Count; i++) {
			if (inventory [i].itemName == null) {
			
				for(int j=0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
					}

				}
				break;

			}
		}


	}

	void RemoveItem(int id)
	{
				for (int i = 0; i < inventory.Count; i++) {
						if (inventory [i].itemID == i) {
								inventory [i] = new Item ();
								break;
						}
				}
		}

	bool InventoryContains(int id)
	{
		bool result = false;
		for (int i=0; i< inventory.Count; i++) {
			result = inventory[i].itemID == id;
			if(result){

				break;
			}
		}

		return result;
	}




		
}