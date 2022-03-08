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

    private DeathEvent DE;

    private void Awake()
    {
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
        myRB = GetComponent<Rigidbody2D>();
        audioSource = FindObjectOfType<AudioSource>();
        DE = FindObjectOfType<DeathEvent>();
    }
    private void Start()
    {
        myRB.velocity = new Vector2(-obstacleSpeed, myRB.velocity.y);
        DE.OnDeath += DE_OnDeath;
    }

    private void DE_OnDeath(object sender, EventArgs e)
    {
        if(myRB != null)
        {
            myRB.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // invoke obstacle hit event
            obstacleHitEvent.HitObstacle();
            audioSource.PlayOneShot(obstacleHitNoise);
            Destroy(gameObject);
        }
    }
}
