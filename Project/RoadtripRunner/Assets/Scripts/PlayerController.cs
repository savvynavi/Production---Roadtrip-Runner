using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	private CharacterController m_controller;
	private Rigidbody m_rigidbody;
	public float m_speed = 0;
	public Vector3 m_jumpSpeed;

	// Use this for initialization
	void Start () {
		CharacterController m_controller = GetComponent<CharacterController>();
		m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_controller.isGrounded == true){
			print("grounded can't fump");
		} else {
			print("can jump");
		}
	}

	void FixedUpdate() {
		m_rigidbody.AddForce(new Vector3(m_speed, 0, 0));
		if(Input.GetButtonDown("Jump") == true && m_controller.isGrounded == true){
			m_rigidbody.AddForce(m_jumpSpeed, ForceMode.VelocityChange);
		}
	}
}
