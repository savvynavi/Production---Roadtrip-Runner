using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	Rigidbody rb;
	public Transform GoHere;
	public float followSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float distance = Vector3.Distance (GoHere.position, transform.position);
		float percentDistance = (((followSpeed - distance) / followSpeed));
		float turnSpeed = followSpeed * (1 - percentDistance);
		if (turnSpeed > followSpeed) 
		{
			turnSpeed = followSpeed;
		}
		Vector3 direction = (GoHere.position - transform.position).normalized;
		rb.MovePosition (transform.position + direction * turnSpeed * Time.deltaTime);
	}
}
