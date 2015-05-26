using UnityEngine;
using System.Collections;

public class PlayNewScene : MonoBehaviour {
	private GameObject player;// Reference to the player.
	public string creds;
	// Use this for initialization
	void Start () {
	
	}
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");

		
	}
	void OnTriggerEnter (Collider other)
	{
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			Application.LoadLevel (creds);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
