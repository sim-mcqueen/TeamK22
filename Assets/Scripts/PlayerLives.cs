using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives;
    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;
    public GameObject player;
    public float waitTime;

    private DeathFade deathFade;
    private ObstacleHitEvent obstacleHitEvent;
    private DeathEvent deathEvent;

    // animation
    private Animator myAnim;


    private void Awake()
    {
        deathEvent = FindObjectOfType<DeathEvent>();
        obstacleHitEvent = FindObjectOfType<ObstacleHitEvent>();
        myAnim = player.GetComponent<Animator>();
        myAnim.SetBool("Hit", false);
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
            if (GetComponent<Animator>() != null)
            {
                myAnim.SetBool("Hit", true);
                StartCoroutine(SwitchRun());
            }
        }
        if(lives == 1) {
            heartTwo.SetActive(false);
            if (GetComponent<Animator>() != null)
            {
                myAnim.SetBool("Hit", true);
                StartCoroutine(SwitchRun());
            }
        }
        if (lives == 0)
        {
            heartOne.SetActive(false);
            myAnim.SetBool("isDead", true);
            deathEvent.Death();
            return;
        }
        
    }

    IEnumerator SwitchRun()
    {
        yield return new WaitForSeconds(waitTime);
        SwitchToRun();
    }

    public void SwitchToRun()
    {
        myAnim.SetBool("Hit", false);
    }
    
}
