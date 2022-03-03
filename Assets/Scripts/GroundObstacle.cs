using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour
{
    public float obstacleSpeed;

    private AudioSource audioSource;
    public AudioClip obstacleHitNoise;

    private Rigidbody2D myRB;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        myRB.velocity = new Vector2(-obstacleSpeed, myRB.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // play obstacle hit sound
            audioSource.PlayOneShot(obstacleHitNoise);
            // play damage animation
            Destroy(gameObject);
        }
    }
}
