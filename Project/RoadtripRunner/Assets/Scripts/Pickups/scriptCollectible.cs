using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptCollectible : MonoBehaviour {
	public Text m_scorePrint;

	public PlayerController m_player;

	// Use this for initialization
	void Start () {
		m_player = m_player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreUpdate();
	}

	void OnTriggerEnter(Collider hit) {
		if(hit.tag == "player"){
			m_player.m_score += 10;
			ScoreUpdate();
			Destroy(this.gameObject);
		}
	}

	void ScoreUpdate() {
		m_scorePrint.text = "Score: " + m_player.m_score.ToString();
	}
}
