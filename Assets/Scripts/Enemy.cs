using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	Transform player;
	NavMeshAgent agent;
	Animator anim;
	Collider col;
	public bool dead { get; set; }
	
	// Use this for initialization
	void Start () {
		// Gets navhmeshageny component from enemy
		agent = GetComponent<NavMeshAgent>();
		col = GetComponent<Collider>();
		anim = GetComponent<Animator>();

		player = GameObject.FindWithTag("Player").transform;
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Follows the player with built-in Unity AI NavMeshAgent
		agent.destination = player.position;

		if (Vector3.Distance(player.position, transform.position) < 2f && !dead)
		{
			SceneManager.LoadScene("Scene1");
		}

	}

	public void Die()
	{
		agent.isStopped = true;
		anim.SetBool("death", true);
		col.isTrigger = true;
		dead = true;
		Destroy(this.gameObject, 20f);

	}




}
