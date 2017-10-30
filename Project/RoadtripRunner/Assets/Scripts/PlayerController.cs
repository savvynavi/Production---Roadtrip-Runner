using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Rigidbody m_rigidbody;
	private bool isJumping;


	//upgrade properties
	public bool FlightUpgrade { get; set; }
	public bool JumpUpgrade { get; set; }
	public bool SpeedUpgrade { get; set; }
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
		JumpUpgrade = false;
		SpeedUpgrade = false;
		Timer = 0;

	}

	void Update() {
		//checks if flight upgrade currently active, if so ticks down active time
		if(FlightUpgrade == true) {
			if(Timer >= 0) {
				//seperate out into fn call?
				Timer -= Time.deltaTime;
			}else {
				FlightUpgrade = false;
			}
		}

		//checks if jump upgrade active, same as above(EDIT OUT MAGIC NUMBERS)
		if(JumpUpgrade == true) {
			if(Timer >= 0 == true) {
				Timer -= Time.deltaTime;
				m_jumpSpeed = new Vector3(2, 12, 0);
			}else {
				JumpUpgrade = false;
				m_jumpSpeed = new Vector3(0, 7, 0);
			}
		}

		//checks if speed upgrade active, same as above(MAGIC NUMBERS ARE BAD NEVER DO THIS CHANGE AFTER TESTING :y)
		if(SpeedUpgrade == true) {
			if(Timer >= 0 == true) {
				Timer -= Time.deltaTime;
				m_maxSpeed = 30;
			}else{
				SpeedUpgrade = false;
				m_maxSpeed = 20;
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
		
		//jump if space pressed And currently grounded/flight mode activated
		if(Input.GetButtonDown("Jump") && (isJumping == false || FlightUpgrade == true)) {
			m_rigidbody.AddForce(m_jumpSpeed, ForceMode.Impulse);
		}
		//delete later, for testing purposes
		TestVelocity = m_rigidbody.velocity;
	}

	//not currently using isGrounded due to no fast/easy way to add gravity while also allowing jumping(maybe change to raycasting to prevent sticking to sides)
	void OnCollisionEnter(Collision hit) {
		isJumping = false;
	}

	void OnCollisionExit(Collision hit) {
		isJumping = true;
	}
}