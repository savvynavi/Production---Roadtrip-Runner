using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFlight : MonoBehaviour {
	public PlayerController m_player;
	public float m_timer;

	// Use this for initialization
	void Start() {
		m_player.GetComponent<PlayerController>();
	}

	void OnTriggerEnter(Collider hit) {
		if(hit.tag == "player") {
			m_player.FlightUpgrade = true;
			m_player.Timer = m_timer;
			Destroy(this.gameObject);
		}
	}

}
