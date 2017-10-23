using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject Player;
    public string PlayerTag = "Player";     //Set this string to whatever the Player object tag is
    public string PlaneTag = "KillFloor";   //Set this string to whatever the plane object tag is


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(PlayerTag);
    }

    void Update()
    {
        Plane TestPlane = new Plane(new Vector3(0, 1, 0), GameObject.FindGameObjectWithTag(PlaneTag).transform.position);

        if (TestPlane.GetSide(Player.transform.position) == false)
            Player.transform.position = transform.position;
    }
}
