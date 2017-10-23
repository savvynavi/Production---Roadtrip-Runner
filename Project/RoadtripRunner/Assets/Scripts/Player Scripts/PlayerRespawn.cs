using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //Note: Don't use on an object with a rigidbody. Rigidbody and character controller hate each other.

    public GameObject SpawnPoint;
    public string RespawnTag = "Respawn"; //Set this string to whatever the respawn object tag is
    public string PlaneTag = "KillFloor"; //Set this string to whatever the plane object tag is


    void Start()
    {
        SpawnPoint = GameObject.FindGameObjectWithTag(RespawnTag);
    }

    void Update()
    {
        Plane TestPlane = new Plane(new Vector3(0, 1, 0), GameObject.FindGameObjectWithTag(PlaneTag).transform.position);

        if (TestPlane.GetSide(gameObject.transform.position) == false)
            gameObject.transform.position = SpawnPoint.transform.position;
    }
}
