using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerY : MonoBehaviour
{
    // jump variables
    public float jumpHeight;
    public float gravity;
    public int maxJumps;
    public int jumpsLeft;

    private bool isGrounded = true;

    // components
    private Rigidbody2D rigidBody;
    private Transform groundCheck;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform.GetChild(0);
    }

    private void Update()
    {
        if(isGrounded) { jumpsLeft = maxJumps; }

        if(jumpsLeft == 0) { return; }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("here");
            if(isGrounded)
            {
                jumpsLeft -= 1;
            }

            rigidBody.velocity += new Vector2(0, jumpHeight);
            isGrounded = false;
        }
    }
}
