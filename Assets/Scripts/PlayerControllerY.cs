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
    public float footStepRate;
    private bool isGrounded = true;
    private bool playHigh = false;
    private float stepCooldown;
    private Color mainColor;

    // components
    private Rigidbody2D rigidBody;
    private Transform groundCheck;
    private SpriteRenderer spriteRenderer;

    // audio
    private AudioSource audioSource;
    public AudioClip jumpNoise;
    public AudioClip landOnGroundNoise;
    public AudioClip footStepNoiseHigh;
    public AudioClip footStepNoiseLow;
    public AudioClip flipGravityNoise;

    // animation
    private Animator myAnim;

    // events
    private GravityEvent gravityEvent;
    private bool isGravityOn = true;
    private ObstacleHitEvent obstacleHitEvent;

    private void Awake()
    {
        gravityEvent = FindObjectOfType<GravityEvent>();
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        gravityEvent.OnGravityChange += GravityEvent_OnGravityChange;
        obstacleHitEvent.OnHitObstacle += ObstacleHitEvent_OnHitObstacle;
        mainColor = spriteRenderer.color;
    }


    private void GravityEvent_OnGravityChange(object sender, System.EventArgs e)
    {
        if(isGravityOn)
        {
            audioSource.PlayOneShot(flipGravityNoise);
            gravity = -28;
            jumpHeight = 15;
            isGravityOn = !isGravityOn;
            return;
        }
        audioSource.PlayOneShot(flipGravityNoise);
        isGravityOn = !isGravityOn;
        gravity = -50;
        jumpHeight = 20;
        return;

    }

    private void ObstacleHitEvent_OnHitObstacle(object sender, System.EventArgs e)
    {
        StartCoroutine(FlashColor(0.25f));
    }

    private void Update()
    {
        if(GetComponent<Animator>() != null)
        {
            myAnim.SetBool("isGrounded", isGrounded);
        }
        

        Physics2D.gravity = new Vector2(0, gravity);

        stepCooldown -= Time.deltaTime;

        if (isGrounded)
        {
            jumpsLeft = maxJumps;

            if (stepCooldown < 0f)
            {
                if (playHigh)
                {
                    audioSource.PlayOneShot(footStepNoiseHigh);
                    playHigh = !playHigh;
                    stepCooldown = footStepRate;
                }
                else
                {
                    audioSource.PlayOneShot(footStepNoiseLow);
                    playHigh = !playHigh;
                    stepCooldown = footStepRate;
                }
            }
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
            playHigh = false;
            audioSource.PlayOneShot(landOnGroundNoise);
        }
        isGrounded = newBool;
    }

    IEnumerator FlashColor(float wait)
    {
        spriteRenderer.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(wait);
        spriteRenderer.color = mainColor;
    }

}
