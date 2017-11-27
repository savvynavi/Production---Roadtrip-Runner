using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughPlatformBooty : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider Other)
	{
		if (Other.CompareTag ("Platform") == true) 
		{
			Other.isTrigger = false;
		}

	}
	void OnTriggerExit(Collider Other)
	{
		if (Other.CompareTag ("Platform") == true) 
		{
			Other.isTrigger = true;
		}
	}
}
