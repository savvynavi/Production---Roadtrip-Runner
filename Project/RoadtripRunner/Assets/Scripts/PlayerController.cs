using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Rigidbody m_rigidbody;
	private bool isJumping;

	public float m_speed = 0;
	public float m_maxSpeed;
	public Vector3 m_jumpSpeed;
	private Vector3 TestVelocity;

	// Use this for initialization
	void Start() {
		m_rigidbody = GetComponent<Rigidbody>();
		isJumping = false;
	}

	//maybe swap back to char cont. for const. movement
	void FixedUpdate() {

		m_rigidbody.AddForce(m_speed, 0, 0);

		if(m_rigidbody.velocity.magnitude >= m_maxSpeed) {
			m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, m_maxSpeed);
		}

		//jump if space pressed And currently grounded
		if(Input.GetButtonDown("Jump") && isJumping == false) {
			//Debug.Log("WEEEE");
			m_rigidbody.AddForce(m_jumpSpeed, ForceMode.Impulse);
			//m_rigidbody.velocity += new Vector3(0, m_jumpSpeed * Time.deltaTime, 0);
		}


		//delete later, for testing purposes
		TestVelocity = m_rigidbody.velocity;
	}

	//not currently using isGrounded due to no fast/easy way to add gravity while also allowing jumping
	void OnCollisionEnter(Collision hit) {
		isJumping = false;
	}

	void OnCollisionExit(Collision hit) {
		isJumping = true;
	}
}
