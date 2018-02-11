using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float minSpawnTime;
	public float maxSpawnTime;

	private float time;
	// Use this for initialization
	void Start () {
		
		time = Random.Range(minSpawnTime, maxSpawnTime);
	}
	
	// Update is called once per frame
	void Update () {

		if (time <= 0)
		{
			GameObject enemy = (GameObject)Resources.Load("npc_001");
			Instantiate(enemy, transform.position, transform.rotation);
			time = Random.Range(minSpawnTime, maxSpawnTime);
		}

		time -= Time.deltaTime;
		
		
	}
}
