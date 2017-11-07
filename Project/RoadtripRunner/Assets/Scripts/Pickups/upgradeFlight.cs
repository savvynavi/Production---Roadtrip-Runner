using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFlight : MonoBehaviour {

	public PlayerController m_player;
	public UpgradeControl m_upgradeControl;
	public float m_timer;

	// Use this for initialization
	void Start() {
		m_player.GetComponent<PlayerController>();
		m_upgradeControl.GetComponent<UpgradeControl>();
	}

	//on trigger, sets player flight check to true and gives it it's active time, then destroys this object
	void OnTriggerEnter(Collider hit) {
		if(hit.tag == "player") {
			m_player.FlightUpgrade = true;
			m_player.Timer = m_timer * (m_upgradeControl.scissorsUpgradesBought + 1);
			Destroy(this.gameObject);
		}
	}
}
