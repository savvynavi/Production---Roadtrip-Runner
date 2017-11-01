using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour 
{
	public Transform m_player;
	public float xThing;
	public float yThing;
	public float zThing;
	public Rigidbody playerRB;
	public Rigidbody doorRB;

	//will follow given objects x-position, but not y or z(won't move up/down with jumps)
	void Update() 
	{
		float xVelocity = playerRB.velocity.x;
		doorRB.velocity = new Vector3 (xVelocity, 0, 0);
	}

	void Start()
	{
		transform.position = new Vector3 (m_player.position.x - xThing, yThing, zThing);
	}
}


