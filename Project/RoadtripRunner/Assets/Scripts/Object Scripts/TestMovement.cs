using UnityEngine;

public class TestMovement : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
        GetComponent<CharacterController>().SimpleMove(new Vector3(-6, 0, 0));
    }
}
