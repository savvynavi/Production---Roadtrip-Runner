using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTCamera : MonoBehaviour {

	public Transform m_player;
	
	// FOR TESTING DO NOT EDIT
	void Update () {
		if(m_player != null) {
			transform.position = new Vector3(m_player.position.x + 10, 7, -13);
		}
	}
}
