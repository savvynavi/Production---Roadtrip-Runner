using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDoorController : MonoBehaviour
{
	public Transform player;
	public float xPos;
	public float yPos;
	public float zPos;

	//will follow given objects x-position, but not y or z(won't move up/down with jumps)
	void Update()
    {
		if (player != null)
			transform.position = new Vector3 (player.position.x - xPos, yPos, zPos);
	}
}
