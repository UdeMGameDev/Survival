using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public bool pickable { get; set; }

	// Use this for initialization
	void Start () {
		
		pickable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player" && pickable)
		{

		}
	}
}
