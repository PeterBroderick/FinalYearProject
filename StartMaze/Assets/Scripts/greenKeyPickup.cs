using UnityEngine;
using System.Collections;

public class greenKeyPickup : MonoBehaviour {

	public AudioClip keyGrab;
	
	public GameObject door;
	private GameObject player;
	private PlayerInventory playerInventory; 
	
	void Awake ()
	{

		player = GameObject.FindGameObjectWithTag("Player");
		playerInventory = player.GetComponent<PlayerInventory>();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			AudioSource.PlayClipAtPoint(keyGrab, transform.position);
			playerInventory.hasKeyGreen = true;
			Destroy(gameObject);
			playerInventory.greenKeyUp =true;
		}
	}
}
