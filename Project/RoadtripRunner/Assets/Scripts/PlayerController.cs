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
		isJumping = true;
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
		//checks if flight/speed/jump upgrade currently active, if so ticks down active time
		if(FlightUpgrade == true) {
			if(Timer >= 0) {
				Timer -= Time.deltaTime;
			}else {
				FlightUpgrade = false;
			}
		}
		if(JumpUpgrade == true) {
			if(Timer >= 0 == true) {
				Timer -= Time.deltaTime;
			}else {
				JumpUpgrade = false;
				ResetJump();
			}
		}
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
		//adding speed to players force, then clamping it to be less than the max speed
		m_rigidbody.AddForce(m_speed, 0, 0);

		Vector3 velocity = m_rigidbody.velocity;

		if(velocity.x >= MaxSpeed) {
			velocity.x = Mathf.Clamp(velocity.x, 0, MaxSpeed);
			m_rigidbody.velocity = velocity;
		}

		//jump if space pressed And currently grounded/flight mode activated
		if(Input.GetButtonDown("Jump") && (isJumping == false || FlightUpgrade == true)) {
			m_rigidbody.AddForce(JumpSpeed, ForceMode.Impulse);
		}

		//testing purposes, delete later
		TestVelocity = m_rigidbody.velocity;
	}

	//checks to see if player is colliding with object, then if it's the floor before setting isJumping to false, prevents wall jumping 
	void OnCollisionEnter(Collision hit) {
		var normal = hit.contacts[0].normal;
		if(normal.y > 0) {
			isJumping = false;
		} else if(normal.y <= 0) {
			isJumping = true;
			//if the speed upgrade is active, will let you "cut" through platforms when hitting their sides
			if(SpeedUpgrade == true && hit.gameObject.CompareTag("Platform")) {
				hit.gameObject.SetActive(false);
			}
		}
	}

	//when not currently grounded, will disable jump
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