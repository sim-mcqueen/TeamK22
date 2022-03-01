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
        transform.position = Vector3.zero;
        startPosition = transform.position;
        offset = new Vector2(scrollSpeed, 0);
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }

}
