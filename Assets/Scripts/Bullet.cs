using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float time = 0;
	Rigidbody rb;
	Collider col;

	public enum State
	{
		floor,
		air,
		picked
	}
	public State state;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();

		state = State.floor;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Increases time since bullet created
		time += Time.deltaTime;

		// if bullet ctreated 5 sec. ago, destroy it
		/*
		if (time >= 5f)
		{
			Destroy(transform.gameObject);
		}
		*/
	}

	void OnTriggerEnter(Collider col)
	{
		if (state == State.air)
		{
			// If bullet collides with enemy, destroy enemy
			if (col.tag != "Player" && col.tag != "Ground" && col.tag != "Item")
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

		else if (state == State.floor)
		{
			if (col.tag == "Player")
			{
				if (col.GetComponent<PlayerController>().bulletObject == null)
				{
					PlayerController pc = col.GetComponent<PlayerController>();
					pickUp(pc);
				}
				

			}
		}
	}

	void Stop()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.useGravity = true;
		this.col.isTrigger = false;
		state = State.floor;
	}

	public void pickUp(PlayerController pc)
	{
		transform.position = pc.bulletStart.position;
		pc.bulletObject = this.gameObject;
		pc.hasItem = true;
		rb.constraints = RigidbodyConstraints.FreezeAll;
		rb.useGravity = false;
		transform.SetParent(pc.transform);
	}

	public void Fire(Vector3 direction)
	{
		transform.SetParent(null);
		rb.AddForce(direction * 2000f);
		state = Bullet.State.air;
		rb.constraints = RigidbodyConstraints.None;
		rb.useGravity = true;
		
	}
		
}
