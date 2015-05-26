using UnityEngine;
using System.Collections;

public class StartFire : MonoBehaviour {
	public GameObject fireEffectMenu;
	public GameObject torchLeft;
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake(){
		//rabbit = GameObject ("Zombunny");
		//rabbit = GameObject.Find ("Zombunny"); 
		
		//AudioSource.PlayClipAtPoint (throwGrenade, transform.position);
		Instantiate(fireEffectMenu, torchLeft.transform.position, Quaternion.identity);
	}
}
