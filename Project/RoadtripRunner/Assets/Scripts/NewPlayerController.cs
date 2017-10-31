using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class NewPlayerController : MonoBehaviour {
	public float m_speed = 10;
	public float m_maxSpeed = 20;
	public float jumpSpeed = 15F;
	public float gravity = 10.0F;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if(controller.isGrounded) {
			moveDirection = new Vector3(1, 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			
			moveDirection *= m_speed;
			if(Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
