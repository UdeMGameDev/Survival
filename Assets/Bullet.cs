using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Increases time since bullet created
		time += Time.deltaTime;

		// if bullet ctreated 5 sec. ago, destroy it
		if (time >= 5f)
		{
			Destroy(transform.gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		// If bullet collides with enemy, destroy enemy
		if (col.tag == "Enemy")
		{
			Destroy(col.gameObject);
		}

		// Destroys bullet
		Destroy(transform.gameObject);
	}
}
