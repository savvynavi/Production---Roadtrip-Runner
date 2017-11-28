using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float xPos;
    public float speed = 5;

    public Transform moveTo;
    public Transform moveFrom;

    public bool playerIsInSky;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player == null) { return; }

        moveTo.position = new Vector3(player.position.x - xPos, moveTo.position.y, moveTo.position.z);
        moveFrom.position = new Vector3(player.position.x - xPos, moveFrom.position.y, moveFrom.position.z);

        transform.LookAt(player);


        Vector3 ToDir = (moveTo.position - transform.position).normalized;
        Vector3 FromDir = (moveFrom.position - transform.position).normalized;

        if (playerIsInSky)
            rb.MovePosition(transform.position + ToDir * speed * Time.deltaTime);
        if (!playerIsInSky)
            rb.MovePosition(transform.position + FromDir * speed * Time.deltaTime);

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
