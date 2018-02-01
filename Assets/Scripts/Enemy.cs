using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public Transform player;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		// Gets navhmeshageny component from enemy
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		// Follows the player with built-in Unity AI NavMeshAgent
		agent.destination = player.position;

		if (Vector3.Distance(player.position, transform.position) < 2f)
		{
			SceneManager.LoadScene("Scene1");
		}

	}

}
