using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyControl : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraObject;
    public float yPos = 30;
    public float zPos = 5;

	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x, yPos, zPos);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != player.tag) { return; }

        CameraScript CS = cameraObject.GetComponent<CameraScript>();
        CS.playerIsInSky = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != player.tag) { return; }
        CameraScript CS = cameraObject.GetComponent<CameraScript>();
        CS.playerIsInSky = false;
    }
}
