using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    public float scrollSpeed;
    private Vector3 startPosition;
    private Material material;
    private Vector2 offset;
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Start()
    {
        // Canvas is invisible otherwise
        transform.position = new Vector3(0, 0, 100);
        startPosition = transform.position;
        offset = new Vector2(scrollSpeed, 0);
    }

    void FixedUpdate()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }

}
