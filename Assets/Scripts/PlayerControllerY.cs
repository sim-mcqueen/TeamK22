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
    public float fallMultiplier;
    public float fallMultiplerWhenNotHoldingJump;
    private bool isGrounded = true;

    // components
    private Rigidbody2D rigidBody;
    private Transform groundCheck;

    // audio
    private AudioSource audioSource;
    public AudioClip jumpNoise;
    public AudioClip landOnGroundNoise;

    // animation
    private Animator myAnim;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        myAnim.SetBool("isGrounded", isGrounded);

        // Jump mechanics
        if (isGrounded) { jumpsLeft = maxJumps; }

        if(rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }
        else if(rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigidBody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplerWhenNotHoldingJump * Time.deltaTime;
        }

        if(jumpsLeft == 0) { return; }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpNoise);
            isGrounded = false;
            jumpsLeft -= 1;
            rigidBody.velocity = new Vector2(0, jumpHeight);
        }
    }

    public void SetIsGrounded(bool newBool)
    {
        if(newBool == true && isGrounded == false)
        {
            audioSource.PlayOneShot(landOnGroundNoise);
        }
        isGrounded = newBool;
    }
}
