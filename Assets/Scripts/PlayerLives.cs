using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives;

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
        if (lives == 0)
        {
            // end game
            return;
        }
    }
}
