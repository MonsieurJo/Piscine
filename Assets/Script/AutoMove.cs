using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

	public float speed;
	private Rigidbody playerRb;
	private Vector3 movement;

	// Use this for initialization
	void Start () {
		movement = new Vector3 (speed, 0.0f, 0.0f);
		playerRb = GetComponent<Rigidbody>();
		playerRb.AddForce(movement, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
