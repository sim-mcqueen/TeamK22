using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives;
    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;

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
        if(lives == 2)
        {
            heartThree.SetActive(false);
        }
        if(lives == 1) {
            heartTwo.SetActive(false);
        }
        if (lives == 0)
        {
            heartOne.SetActive(false);
            deathEvent.Death();
            return;
        }
        
    }
}
