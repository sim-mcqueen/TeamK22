using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float speedMultiplier;
    private Vector3 offset;
    public float minWidth;
    public float maxWidth;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(minWidth, maxWidth), transform.localScale.y);
        offset = new Vector3(-speed * speedMultiplier, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += offset;
    }
}
