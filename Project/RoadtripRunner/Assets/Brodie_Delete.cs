using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Brodie_Delete : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
            print("We are grounded");
        
    }
}
