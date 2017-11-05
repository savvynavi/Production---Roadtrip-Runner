using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Rigidbody m_rigidbody;
	private bool isJumping;
	private float m_setMaxSpeed;
	private Vector3 m_setJumpHeight;

	//upgrade properties
	public bool FlightUpgrade { get; set; }
	public bool JumpUpgrade { get; set; }
	public bool SpeedUpgrade { get; set; }
	public float Timer { get; set; }

	public float MaxSpeed { get; set; }
	public Vector3 JumpSpeed { get; set; }
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
		MaxSpeed = m_maxSpeed;
		JumpSpeed = m_jumpSpeed;
		m_setJumpHeight = m_jumpSpeed;
		m_setMaxSpeed = m_maxSpeed;
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

		//checks if jump upgrade active, same as above
		if(JumpUpgrade == true) {
			if(Timer >= 0 == true) {
				Timer -= Time.deltaTime;
			}else {
				JumpUpgrade = false;
				ResetJump();
			}
		}

		//checks if speed upgrade active, same as above
		if(SpeedUpgrade == true) {
			if(Timer >= 0 == true) {
				Timer -= Time.deltaTime;
			}else{
				SpeedUpgrade = false;
				ResetSpeed();
			}
		}
	}

	void FixedUpdate() {
		//adding speed to players force, then clamping it to be less than 20
		m_rigidbody.AddForce(m_speed, 0, 0);
		if(m_rigidbody.velocity.magnitude >= MaxSpeed) {
			m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, MaxSpeed);
		}
		
		//jump if space pressed And currently grounded/flight mode activated
		if(Input.GetButtonDown("Jump") && (isJumping == false || FlightUpgrade == true)) {
			m_rigidbody.AddForce(JumpSpeed, ForceMode.Impulse);
		}

		TestVelocity = m_rigidbody.velocity;
	}

	//checks to see if player is colliding with object, then if it's the floor before setting isJumping to false, prevents wall jumping 
	void OnCollisionEnter(Collision hit) {
		var normal = hit.contacts[0].normal;
		if(normal.y > 0) {
			isJumping = false;
		} else if(normal.y <= 0) {
			isJumping = true;
		}
	}

	//when not currently grounded, will 
	void OnCollisionExit(Collision hit) {
		isJumping = true;
	}


	void ResetSpeed() {
		MaxSpeed = m_setMaxSpeed;
	}

	void ResetJump() {
		JumpSpeed = m_setJumpHeight;
	}
}