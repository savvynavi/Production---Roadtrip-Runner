using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Player;
    public string PlayerTag = "Player";     //Set this string to whatever the Player object tag is
    public string PlaneTag = "KillFloor";   //Set this string to whatever the plane object tag is
    private bool ActiveCheckpoint;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(PlayerTag);
    }

    void OnTriggerEnter(Collider other)
    {
        if (ActiveCheckpoint == false)
            ActiveCheckpoint = true;
    }

    void Update()
    {
        Plane TestPlane = new Plane(new Vector3(0, 1, 0), GameObject.FindGameObjectWithTag(PlaneTag).transform.position;

        if (TestPlane.GetSide(Player.transform.position) == false && ActiveCheckpoint == true)
            Player.transform.position = gameObject.transform.position;

        Player.GetComponent<CharacterController>().SimpleMove(new Vector3(-8, 0, 0));
    }
}
