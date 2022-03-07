using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidMovement : MonoBehaviour
{
    public float moveTime;
    private int lives = 3;
    public float firstLifePos;
    public float secondLifePos;
    public float thirdLifePos;
    private ObstacleHitEvent obstacleHitEvent;

    private void Awake()
    {
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
    }

    private void Start()
    {
        obstacleHitEvent.OnHitObstacle += ObstacleHitEvent_OnHitObstacle;
    }

    private void ObstacleHitEvent_OnHitObstacle(object sender, System.EventArgs e)
    {
        lives -= 1;
        if(lives == 2)
        {
            StartCoroutine(LerpTo(firstLifePos));
        }
        if (lives == 1)
        {
            StartCoroutine(LerpTo(secondLifePos));
        }
        if (lives == 0)
        {
            StartCoroutine(LerpTo(thirdLifePos));
        }
    }

    IEnumerator LerpTo(float newPos)
    {
        float elapsedTime = 0;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector2(newPos, 0), (elapsedTime / moveTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = new Vector2(newPos, 0);
    }
}
