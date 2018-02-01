using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	// Test pour gitHub


	CharacterController cc;

	// Gets bullet reference
	public Transform bulletStart;
	public GameObject bulletObject;

	// Sets player stats
	public float fireRate = 0.5f;
	public float speed = 8f;

	float timeBeforeShot = 0f;



	// Use this for initialization
	void Start () 
	{
		// Gets the character controller component
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Takes player input
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		

		// Creates a direction vector and normalizes it
		Vector3 direction = new Vector3(x, 0f, z);
		direction.Normalize();

		// Move the player according to direction (times speed)
		cc.Move(direction * Time.deltaTime * speed);

		// Rotates the player with a Raycast
		// (sends a ray from camera center to mouse, then set the forward direction of
		// the player in that direction)
		RaycastHit lookHit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out lookHit, 1000f))
		{
			Vector3 directionRaw = lookHit.point - transform.position;
			transform.forward = new Vector3 (directionRaw.x, 0f, directionRaw.z);
		}
		

		// If player presses space and can shoot
		if (Input.GetKeyDown(KeyCode.Space) && timeBeforeShot <= 0f)
		{
			timeBeforeShot = fireRate;

			// Instantiate bullet and shoots it
			GameObject bullet = Instantiate(bulletObject, bulletStart);
			bullet.transform.SetParent(null);
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
		}

		timeBeforeShot -= Time.deltaTime;
		
	}
}
