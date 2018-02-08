using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	CharacterController cc;
	Animator animator;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (cc.velocity.magnitude > 0f)
		{
			
			Vector3 velocityNorm = cc.velocity.normalized;


			float scalarProjX = Vector3.Dot (velocityNorm, transform.forward) / transform.forward.magnitude;
			float scalarProjZ = Vector3.Dot (velocityNorm, transform.right) / transform.right.magnitude;
	

			animator.SetFloat ("y", scalarProjX, 0.2f, Time.deltaTime);
			animator.SetFloat ("x", scalarProjZ, 0.2f, Time.deltaTime);
		}
		else
		{
			animator.SetFloat ("y", 0, 0.2f, Time.deltaTime);
			animator.SetFloat ("x", 0, 0.2f, Time.deltaTime);
		}


		
	}
}
