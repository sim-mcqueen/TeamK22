using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GroundObstacle : MonoBehaviour
{
    public float obstacleSpeed;


    public AudioClip obstacleHitNoise;
    private AudioSource audioSource;

    private ObstacleHitEvent obstacleHitEvent;

    private Rigidbody2D myRB;

    private void Awake()
    {
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
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
            obstacleHitEvent.HitObstacle();
            audioSource.PlayOneShot(obstacleHitNoise);
            // play damage animation
            Destroy(gameObject);
        }
    }
}
