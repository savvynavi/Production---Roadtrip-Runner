using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	private Rigidbody m_rigidbody;
	private CapsuleCollider m_collider;
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
	public float m_nearGroundDistModifier = 0.5f;
	public bool m_nearGround;
	public float m_percentOfSpeed = 0;

	private Vector3 TestVelocity;

	public Animator m_AnimControl;
	// Use this for initialization
	void Start() {
		m_rigidbody = GetComponent<Rigidbody>();
		m_collider = GetComponent<CapsuleCollider>();
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
		//sending info to animator
		m_AnimControl.SetFloat ("speed", m_percentOfSpeed);

		isJumping = true;
		m_nearGround = false;

		//checks if grounded and if not, if it is close to the ground
		if(DistAboveGround(0.2f) != null) {
			print("TEST");
			isJumping = false;
		}else if(DistAboveGround(m_nearGroundDistModifier) != null && isJumping == true) {
			print("INSERT LANDING ANIMATION HERE");
			m_nearGround = true;
		}

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
			m_AnimControl.SetTrigger ("IsJumping");
		}


		if((((m_rigidbody.velocity.x - m_speed) / (MaxSpeed - m_speed)) * 100) <= 0) {
			m_percentOfSpeed = 0;
		}else {
			m_percentOfSpeed = ((m_rigidbody.velocity.x - m_speed) / (MaxSpeed - m_speed)) * 100;
		}

		//testing purposes, delete later
		TestVelocity = m_rigidbody.velocity;
	}

	//detects if a spherecast (taking dist mod as a paramater) is hitting the platforms(returns null when not hitting anything)
	//can be used to both detect if player is grounded or just near the ground by using different distances
	Collider DistAboveGround(float distanceMod) {
		RaycastHit hit;
		Vector3 localScale = transform.lossyScale;
		float castRadius = m_collider.radius * localScale.x;
		float castDistance = localScale.x * ((m_collider.height / 2) - castRadius) + distanceMod;
		LayerMask layermask = 1 << 11;
		if(Physics.SphereCast(m_rigidbody.position + Vector3.up * castRadius, castRadius, -Vector3.up, out hit, castDistance, layermask)) {
			if(hit.normal.y > 0) {
				return hit.collider;
			}
		}
		return null;
	}

	//resets speed/jump values after a powerup has timed out
	void ResetSpeed() {
		MaxSpeed = m_setMaxSpeed;
	}

	void ResetJump() {
		JumpSpeed = m_setJumpHeight;
	}
}