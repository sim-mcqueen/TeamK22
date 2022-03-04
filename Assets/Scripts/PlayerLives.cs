using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives;

    private DeathFade deathFade;
    private ObstacleHitEvent obstacleHitEvent;

    private void Awake()
    {
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
        deathFade = FindObjectOfType<DeathFade>();
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
            deathFade.StartDeath();
            return;
        }
    }
}
