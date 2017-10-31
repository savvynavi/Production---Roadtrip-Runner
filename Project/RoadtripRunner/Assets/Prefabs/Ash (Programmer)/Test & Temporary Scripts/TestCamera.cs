using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public GameObject player;
	
	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
	}
}
