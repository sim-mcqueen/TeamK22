using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public GameObject player;
    public float bounceHeight;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.velocity += new Vector2(0, bounceHeight);
        }
    }
}
