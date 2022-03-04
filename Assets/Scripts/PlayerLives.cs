using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives;

    private DeathFade deathFade;
    private ObstacleHitEvent obstacleHitEvent;
    private DeathEvent deathEvent;

    private void Awake()
    {
        deathEvent = FindObjectOfType<DeathEvent>();
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
            deathEvent.Death();
            return;
        }
    }
}
