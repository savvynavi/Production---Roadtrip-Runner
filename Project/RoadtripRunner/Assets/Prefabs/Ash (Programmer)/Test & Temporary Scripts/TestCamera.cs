using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public GameObject player;
	
    void Start()
    {
        transform.Rotate(new Vector3(10, 1, 0), 2);
    }

    void Update ()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4, -20);
	}
}
