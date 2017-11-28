using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public Transform pos1;
    public Transform pos2;

    public float playerYOrigin = 10;
    public float playerYMax = 60;

    public float percent;


    void Start ()
    {
        playerYOrigin = player.transform.position.y;
    }
	
	void Update ()
    {
        if (player == null) { return; }

        if (player.transform.position.y < 12)
            playerYMax = 40;

        pos1.position = new Vector3(player.transform.position.x - 2, pos1.position.y, pos1.position.z);
        pos2.position = new Vector3(player.transform.position.x - 2, pos2.position.y, pos2.position.z);

        Vector3 targetPoint = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);

        percent = player.transform.position.y / playerYMax;
        transform.position = Vector3.Lerp(pos1.position, pos2.position, percent);
    }
}
