using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Rigidbody m_rigidbody;
	private bool isJumping;


	public bool FlightUpgrade { get; set; }
	public float Timer { get; set; }
	public int m_score;

	public float m_speed = 0;
	public float m_maxSpeed;
	public Vector3 m_jumpSpeed;
	private Vector3 TestVelocity;

	// Use this for initialization
	void Start() {
		m_rigidbody = GetComponent<Rigidbody>();
		isJumping = false;
		FlightUpgrade = false;
		Timer = 0;

	}

	void Update() {
		if(FlightUpgrade == true) {
			if(Timer >= 0) {
				Timer -= Time.deltaTime;
			}else {
				FlightUpgrade = false;
			}
		}
	}

	//maybe swap back to char cont. for const. movement
	void FixedUpdate() {
		//adding speed to players force, then clamping it to be less than 20
		m_rigidbody.AddForce(m_speed, 0, 0);
		if(m_rigidbody.velocity.magnitude >= m_maxSpeed) {
			m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, m_maxSpeed);
		}
		
		//jump if space pressed And currently grounded
		if(Input.GetButtonDown("Jump") && (isJumping == false || FlightUpgrade == true)) {
			m_rigidbody.AddForce(m_jumpSpeed, ForceMode.Impulse);
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


