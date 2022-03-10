using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float slowTime;
    private float startScrollSpeed;
    public float endScrollSpeed;
    private Vector3 startPosition;
    private Material material;
    private Vector2 offset;
    private DeathEvent DE;
    private ObstacleHitEvent obstacleHitEvent;
    private bool dead = false;

    private void Awake()
    {
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
        DE = FindObjectOfType<DeathEvent>();
        material = GetComponent<Renderer>().material;
    }
    

    private void ObstacleHitEvent_OnHitObstacle(object sender, System.EventArgs e)
    {
        StartCoroutine(SlowScroll());
    }

    private void DE_OnDeath(object sender, System.EventArgs e)
    {
        dead = true;
        offset = new Vector2(0, 0);
    }

    private void Start()
    {
        // Canvas is invisible otherwise
        startScrollSpeed = scrollSpeed;
        obstacleHitEvent.OnHitObstacle += ObstacleHitEvent_OnHitObstacle;
        transform.position = new Vector3(0, 0, 100);
        startPosition = transform.position;
        offset = new Vector2(scrollSpeed, 0);
        DE.OnDeath += DE_OnDeath;
    }

    void FixedUpdate()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }

    IEnumerator SlowScroll()
    {
        float elapsedTime = 0;

        while (elapsedTime < (slowTime))
        {
            if(!dead)
            {
                scrollSpeed = Mathf.Lerp(startScrollSpeed, endScrollSpeed, elapsedTime / slowTime);
                offset = new Vector2(scrollSpeed, 0);
                elapsedTime += Time.deltaTime;

            }

            yield return null;
        }


        StartCoroutine(SpeedScroll());
    }

    IEnumerator SpeedScroll()
    {
        float elapsedTime = 0;

        while (elapsedTime < (slowTime))
        {
            if(!dead)
            {
                scrollSpeed = Mathf.Lerp(endScrollSpeed, startScrollSpeed, elapsedTime / slowTime);
                offset = new Vector2(scrollSpeed, 0);
                elapsedTime += Time.deltaTime;

            }


            yield return null;
        }
    }

}
