using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    private float gravity = 9.3f;
    public float baseJumpHeight = 4f;
    public float addedJumpHeight = 0.08f;


    void Start ()
    {
		
	}
	
	void Update ()
    {
        CharacterController control = GetComponent<CharacterController>();

        if (Input.GetButton("Jump") == true)
        {
            if (control.isGrounded)
                moveDirection.y = baseJumpHeight;
            else
                moveDirection.y += addedJumpHeight;
        }

        moveDirection.x -= 8 * Time.deltaTime;
        moveDirection.y -= gravity * Time.deltaTime;
        if (moveDirection.x < -8)
            moveDirection.x = -8;
        control.Move(moveDirection * Time.deltaTime);

        if (transform.position.x <= -140)
            transform.position = new Vector3(16, 2, 0);
    }
}
