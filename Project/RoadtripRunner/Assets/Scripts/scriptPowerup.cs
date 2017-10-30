using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPowerup : MonoBehaviour {

	public bool Flying { get; private set; }
	public float FlyTimer { get; set; }

	// Use this for initialization
	void Start () {
		Flying = true;
		//m_timer = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//void OnTriggerEnter(Collider hit){
	//	if(hit.tag == "player"){
	//		Destroy(this.gameObject);
	//	}
	//}
}
