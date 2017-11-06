using UnityEngine;

//SCRIPT EFFECT:
//The last respawn point collided with by the Player becomes the only active respawn point. The Player will be moved to the active point when they pass below the plane

public class RespawnScript : MonoBehaviour
{
    public string playerTag = "Player";                 //Set this string to whatever the Player object tag is
    public string planeTag = "KillFloor";               //Set this string to whatever the plane object tag is

    public GameObject player;
    private Plane testPlane;

    public bool respawnActive = false;                  //For use when multiple respawn points are implemented

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        testPlane = new Plane(new Vector3(0, 1, 0), GameObject.FindGameObjectWithTag(planeTag).transform.position);
    }

    void Update()
    {
        if (testPlane.GetSide(player.transform.position) == false && respawnActive == true)
            player.transform.position = transform.position;
    }


    void OnTriggerEnter(Collider other)
    {
        GameObject[] Respawns = GameObject.FindGameObjectsWithTag(this.tag);     
        if (Respawns.Length == 0 || other.tag != playerTag) { return; }             //Find all respawn objects through Respawn tag, exit function if there are none

        foreach (GameObject SpawnPoint in Respawns)
            SpawnPoint.GetComponent<RespawnScript>().respawnActive = false;         //Set all respawn objects to be inactive

        respawnActive = true;                                                       //Set this particular respawn object to be active
    }
}