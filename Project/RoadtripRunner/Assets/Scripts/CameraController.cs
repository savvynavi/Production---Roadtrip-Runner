using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform m_player;
	public float xThing;
	public float yThing;
	public float zThing;

	//will follow given objects x-position, but not y or z(won't move up/down with jumps)
	void Update() {
		if(m_player != null) {
			transform.position = new Vector3(m_player.position.x - xThing, yThing, zThing);
			transform.LookAt (m_player);
		}
	}

}
