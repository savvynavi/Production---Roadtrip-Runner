using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	bool paused;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !paused) {
			Time.timeScale = 0f;
			paused = true;
			// show menu
		} else if (Input.GetKeyDown (KeyCode.Escape) && paused) 
		{
			Time.timeScale = 1f;
			paused = false;
			// take down menu
		}
	}
}
