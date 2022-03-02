using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    private Vector3 offset;
    public float minWidth;
    public float maxWidth;
    private Rigidbody2D myRB;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.localScale = new Vector3(Random.Range(minWidth, maxWidth), transform.localScale.y);
        myRB.velocity = new Vector2(-speed, 0);
    }
}
