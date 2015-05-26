using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 2f;     // The time in seconds between each attack.
	public float timeAfterAttacks = 4f;  
	public int attackDamage = 10;               // The amount of health taken away per attack.
	public float duration = 4f;  
	AudioSource spear;
	Animator anim;                              // Reference to the animator component.
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
	//EnemyHealth enemyHealth;                    // Reference to this enemy's health.
	bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
	float timer;                                // Timer for counting up to the next attack.
	//AudioSource spear; 
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
		spear = GetComponent <AudioSource> ();

	}
	
	
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is in range.
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is no longer in range.
			playerInRange = false;
		}
	}	
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		
		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if((timer >= timeBetweenAttacks) && (playerInRange) )//&& enemyHealth.currentHealth > 0
		{
			// ... attack.

			Attack ();
		}
		
		// If the player has zero or less health...
		if(playerHealth.currentHealth <= 0)
		{
			// ... tell the animator the player is dead.
			anim.SetTrigger ("PlayerDead");
		}
	}
	
	IEnumerator Wait(float duration)
	{
		//This is a coroutine
		yield return new WaitForSeconds(duration);   //Wait
	}

	void Attack ()
	{
		// If the player has health to lose...
		if(playerHealth.currentHealth > 0)
		{
			animation.Stop("run");
			animation.Play("attack");
			Wait(duration);//yield return new WaitForSeconds(duration);
			playerHealth.TakeDamage (attackDamage);
			spear.Play ();
		}
		timer = 0f;
	}
}