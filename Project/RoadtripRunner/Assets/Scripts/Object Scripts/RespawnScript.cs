using UnityEngine;

//SCRIPT EFFECT:
//The last respawn point collided with by the Player becomes the only active respawn point. The Player will be moved to the active point when they pass below the plane

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public string playerTag = "Player";     //Set this string to whatever the Player object tag is
    public string planeTag = "KillFloor";   //Set this string to whatever the plane object tag is
    public bool respawnActive = false;      //For use when multiple respawn points are implemented

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    void OnTriggerEnter(Collider other)
    {
        //Find all respawn objects through Respawn tag, exit function if there are none
        GameObject[] Respawns = GameObject.FindGameObjectsWithTag(this.tag);
        if (Respawns.Length == 0 || other.tag != playerTag) { return; }

        //Set all respawn objects to be inactive
        foreach (GameObject SpawnPoint in Respawns)
            SpawnPoint.GetComponent<RespawnScript>().respawnActive = false;

        //Set this particular respawn object to be active, so that now *only* this particular respawn point is active
        respawnActive = true;
    }

    void Update()
    {
        Plane TestPlane = new Plane(new Vector3(0, 1, 0), GameObject.FindGameObjectWithTag(planeTag).transform.position);

        if (TestPlane.GetSide(player.transform.position) == false && respawnActive == true)
            player.transform.position = transform.position;
    }
}