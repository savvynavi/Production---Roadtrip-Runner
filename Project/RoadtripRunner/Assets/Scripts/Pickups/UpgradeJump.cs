using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeJump : MonoBehaviour {

	public PlayerController m_player;
	public UpgradeControl m_upgradeControl;
	public float m_timer;
	public Vector3 m_newJumpHeight;

	// Use this for initialization
	void Start () {
		m_player.GetComponent<PlayerController>();
		m_upgradeControl.GetComponent<UpgradeControl>();
	}
	
	//on trigger with player, sets players jumpUpgrade to true and feeds it its active time
	void OnTriggerEnter(Collider hit) {
		if(hit.tag == "player") {
			m_player.JumpUpgrade = true;
			m_player.Timer = m_timer;
			m_player.JumpSpeed = m_newJumpHeight * (m_upgradeControl.rockUpgradesBought + 1);
			Destroy(this.gameObject);
		}
	}
}
