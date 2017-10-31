using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpeed : MonoBehaviour {

	public PlayerController m_player;
	public float m_timer;
	public float m_newMaxSpeed;

	// Use this for initialization
	void Start() {
		m_player.GetComponent<PlayerController>();
	}


	// Update is called once per frame
	void OnTriggerEnter(Collider hit) {
		if(hit.tag == "player") {
			m_player.SpeedUpgrade = true;
			m_player.Timer = m_timer;
			m_player.MaxSpeed = m_newMaxSpeed;
			Destroy(this.gameObject);
		}
	}
}
