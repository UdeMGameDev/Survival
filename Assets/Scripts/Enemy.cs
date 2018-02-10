using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	Transform player;
	NavMeshAgent agent;
	Animator anim;
	bool dead;

	// Use this for initialization
	void Start () {
		// Gets navhmeshageny component from enemy
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindWithTag("Player").transform;
		anim = GetComponent<Animator>();
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
		dead = true;
	}


}
