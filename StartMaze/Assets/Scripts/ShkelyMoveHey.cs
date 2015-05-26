using UnityEngine;
using System.Collections;

public class ShkelyMoveHey : MonoBehaviour {

	public float timeBetweenAttacks = 5f;
	public float allowableDist = 3f;
	public int attackDamage = 10;  
	public Transform player2;
	GameObject player; 
	Animator anim; 
	NavMeshAgent nav;
	bool playerInRange;  
	bool yoke =true; 
	float timer;  

	void Awake ()
	{
		player2 = GameObject.FindGameObjectWithTag ("Player").transform;
		player = GameObject.FindGameObjectWithTag ("Player");
		nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent <Animator> ();
	}


	//Test
	void OnTriggerEnter (Collider other)
	{
		// If the entering collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is in range.
			playerInRange = true;
			yoke =false;
		}
	}

	void OnTriggerExit (Collider other)
	{
		//animation.Play("run");
		// If the exiting collider is the player...
		if(other.gameObject == player)
		{
			// ... the player is no longer in range.
			playerInRange = false;
		}

	}

	void Update ()
	{
		float dist = Vector3.Distance(player2.position, transform.position);

		if (dist < allowableDist) {

						if (playerInRange == false && yoke == true) {
								animation.Play ("run");
						}
						timer += Time.deltaTime;
		
						// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
						if (timer >= timeBetweenAttacks && playerInRange) {//&& enemyHealth.currentHealth > 0
								// 
			
								Attack ();
						} else if (playerInRange == false) {
								//animation.Stop("attack");
								//animation.Play("run");

								Run ();
						}


						nav.SetDestination (player2.position);

				} else if (dist > allowableDist) {
			animation.Play ("idle");
		}
	}

	void Attack ()
	{

		timer = 0f;
		animation.Stop("run");
		animation.Play("attack");

	}

	void Run ()
	{
		animation.Stop("attack");
		animation.Play("run");

	}
}
