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
		//constant  +x movement clamped to maxSpeed
		//m_rigidbody.velocity = new Vector3(m_speed, m_jumpSpeed.y, 0);
		//m_rigidbody.velocity = new Vector3 (Mathf.Clamp(m_rigidbody.velocity.x, m_speed, m_maxSpeed), 0, 0);

		//take 2



		//clamping only x value
		//Vector3 localVelocity = transform.InverseTransformPoint(m_rigidbody.velocity);
		//localVelocity.x = Mathf.Clamp(m_rigidbody.velocity.x * Time.deltaTime, m_speed, m_maxSpeed);
		//m_rigidbody.velocity = transform.TransformPoint(localVelocity);

		//jump if space pressed And currently grounded
		if(Input.GetButtonDown("Jump") && isJumping == false) {
			Debug.Log("WEEEE");
			m_rigidbody.AddForce(new Vector3(0, m_jumpSpeed.y, 0), ForceMode.Impulse);
			//m_rigidbody.velocity += new Vector3(0, m_jumpSpeed * Time.deltaTime, 0);
		}

		m_rigidbody.velocity *= Time.deltaTime;

		if(m_rigidbody.velocity.x >= m_maxSpeed) {
			m_rigidbody.velocity = new Vector3(m_maxSpeed, m_rigidbody.velocity.y, m_rigidbody.velocity.z);
		} else {
			m_rigidbody.velocity += new Vector3(m_speed, 0, 0);
		}

		//m_rigidbody.AddForce(m_rigidbody.velocity);



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
