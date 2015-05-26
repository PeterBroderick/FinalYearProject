﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public AudioClip deathClip;                                 // The audio clip to play when the player dies.
	public float flashSpeed = 5f;
	public float duration = 5f; 
	// The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
	public int getHealth = 5;
	public GameObject heart;
	public PlayerInventory playerInventory;        // Reference to the player's inventory.
	private ItemDatabase database;
	private Inventory inventory; 
	Animator anim;                                              // Reference to the Animator component.
	AudioSource playerAudio;                                    // Reference to the AudioSource component.
	PlayerMovement playerMovement;                              // Reference to the player's movement.
	//PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.
	public string gameOverScreen;
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
		playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <PlayerMovement> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		heart = GameObject.Find ("SimpleHeart1");
		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			//damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damaged = false;
	}


	IEnumerator Wait(float duration)
	{
		//This is a coroutine
		yield return new WaitForSeconds(duration);   //Wait
	}
	
	public void TakeDamage (int amount)
	{
		Wait(duration);
		//yield return new WaitForSeconds(2);
		// Set the damaged flag so the screen will flash.
		damaged = true;
		
		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		
		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;
		
		// Play the hurt sound effect.
		playerAudio.Play ();
		
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 20 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}

	void OnTriggerEnter (Collider other)
	{	
		// If the colliding gameobject is the player...
		if (other.gameObject == heart) 
		{
			if(currentHealth <= 95)
			{
				// Reduce the current health by the damage amount.
				currentHealth = currentHealth + getHealth; 
				
				// Set the health bar's value to the current health.
				healthSlider.value = currentHealth;
				
				Destroy(heart);
			}
			else{
				//currentHealth = currentHealth;
				//Destroy(heart);
				//playerInventory.hasHeart1 = true;

			}
			
		}
		if (other.transform.tag == "Spike") {
			//damaged = true;
			if(currentHealth <= 20 && !isDead)
			{
				// ... it should die.
				Death ();
			}
			// Reduce the current health by the damage amount.
			currentHealth -= 50;
			
			// Set the health bar's value to the current health.
			healthSlider.value = currentHealth;
			
			// Play the hurt sound effect.
			playerAudio.Play ();
		}
	}

	void Death ()
	{
		isDead = true;
		Application.LoadLevel (gameOverScreen);
		playerMovement.enabled = false;
	}       
}