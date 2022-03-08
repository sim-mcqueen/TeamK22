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
    private DeathEvent DE;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        DE = FindObjectOfType<DeathEvent>();
    }

    void Start()
    {
        transform.localScale = new Vector3(Random.Range(minWidth, maxWidth), transform.localScale.y);
        myRB.velocity = new Vector2(-speed, 0);
        DE.OnDeath += DE_OnDeath;
    }

    private void DE_OnDeath(object sender, System.EventArgs e)
    {
        if(myRB != null)
        {
            myRB.velocity = new Vector2(0, 0);
        }
        
    }
}
