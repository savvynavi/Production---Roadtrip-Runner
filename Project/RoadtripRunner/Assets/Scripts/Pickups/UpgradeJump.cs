using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeJump : MonoBehaviour {

	public PlayerController m_player;
	public float m_timer;

	// Use this for initialization
	void Start () {
		m_player.GetComponent<PlayerController>();
	}
	
	//on trigger with player, sets players jumpUpgrade to true and feeds it its active time
	void OnTriggerEnter(Collider hit) {
		if(hit.tag == "player") {
			m_player.JumpUpgrade = true;
			m_player.Timer = m_timer;
			Destroy(this.gameObject);
		}
	}
}
