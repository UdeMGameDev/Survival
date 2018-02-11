using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float time = 0;
	Rigidbody rb;
	Collider col;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
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
		if (col.tag != "Player")
		{
			
			if (col.tag == "Enemy")
			{
				if (!col.GetComponent<Enemy>().dead)
				{
					col.GetComponent<Enemy>().Die();
					Stop();
				}
			}
			else
			{
				Stop();
			}

		}
	}

	void Stop()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.useGravity = true;
		this.col.isTrigger = false;
	}
		
}
