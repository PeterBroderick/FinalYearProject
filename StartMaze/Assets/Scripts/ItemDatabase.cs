using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();
	private PlayerInventory playerInventory;
	private GameObject player;

	void Awake()

	{
		items.Add (new Item ("I_Key05",0, "Opens Blue Doors",0,0, Item.ItemType.Quest));
		items.Add (new Item ("S_Shadow02",1, "Explode when they hit enemies",2,2, Item.ItemType.Weapon));
		items.Add (new Item ("redKey",2, "Opens Red Doors",0,0, Item.ItemType.Quest));
		items.Add (new Item ("S_Holy01",3, "Restores Health",0,0, Item.ItemType.Consumable));
		items.Add (new Item ("I_Key02",4, "Opens Green Doors",0,0, Item.ItemType.Quest));
		items.Add (new Item ("W_Book03",5, "Maybe I should bring this back to the mage.",0,0, Item.ItemType.Quest));
		items.Add (new Item ("I_Map",6, "A map! this might help me escape the maze. (press M to use).",0,0, Item.ItemType.Quest));
		items.Add (new Item ("I_Torch02",7, "Hmm... these might help me to remempber where I've been in the maze.(press F to place).",0,0, Item.ItemType.Quest));
	}
	void Update()
	{

	}


}
