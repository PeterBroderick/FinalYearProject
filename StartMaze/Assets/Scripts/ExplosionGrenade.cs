using UnityEngine;
using System.Collections;

public class ExplosionGrenade : MonoBehaviour {



	//public AudioClip explodeGrenade;
	float lifespan = 3.0f;
	public GameObject fireEffect;
	public GameObject fireEffect2;
	public GameObject rabbit;
	public AudioClip explodeGrenade;
	public GameObject cube;
	private PlayerInventory playerInventory;

	void Start () {
	}

	void Awake(){
	}

	void Update () { 

		lifespan -= Time.deltaTime;
			
		if(lifespan <= 0) {
			Explode ();
		}
	}

	void OnCollisionEnter(Collision collision) 
	{
		
		if (collision.gameObject.tag == "Enemy") 
		{
			//rabbit = GameObject("Zombunny");
			collision.gameObject.tag = "Untagged";
			Instantiate(fireEffect, collision.transform.position, Quaternion.identity);
			Destroy (collision.gameObject);

			AudioSource.PlayClipAtPoint (explodeGrenade, transform.position);

			Explode ();
		}

		else if (collision.gameObject.tag == "EnemyBoss") 
		{
			//rabbit = GameObject("Zombunny");
			collision.gameObject.tag = "Untagged";
			Instantiate(cube, collision.transform.position, Quaternion.identity);
			Destroy (collision.gameObject);
			
			AudioSource.PlayClipAtPoint (explodeGrenade, transform.position);
			
			Explode ();
		}	
	}
				
	void Explode() {
		Destroy (gameObject, 2f);
		playerInventory.enemyDead = true;
	}		
}
