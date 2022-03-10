using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KScoreText : MonoBehaviour
{
    private int Score;
    public float deltaScore;
    private bool StopScore;
    public GameObject text;
    private DeathEvent DE;

    private int num;
    private bool eventActive = false;
    private GravityEvent gravityEvent;
    private RotateCameraEvent rotateCameraEvent;
    private RandomizeStarEvent randomizeStarEvent;
    private void Awake()
    {
        randomizeStarEvent = FindObjectOfType<RandomizeStarEvent>();
        rotateCameraEvent = FindObjectOfType<RotateCameraEvent>();
        gravityEvent = FindObjectOfType<GravityEvent>();
        DE = FindObjectOfType<DeathEvent>();
    }

    

    private void Start()
    {
        StartCoroutine(IncreaseScore());
        DE.OnDeath += DE_OnDeath;
    }


    private void DE_OnDeath(object sender, System.EventArgs e)
    {
        StopCounting();
    }

    IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(deltaScore);
        Score++;
        if(Score % 100 == 0)
        {
            eventActive = true;
            num = Random.Range(0, 3);
            num = 1;
            if (num == 0)
            {
                gravityEvent.ChangeGravity();
            }
            if(num == 1)
            {
                rotateCameraEvent.RotateCamera();
            }
            if(num == 2)
            {
                randomizeStarEvent.RandomizeStar();
            }
        }

        text.GetComponent<TextMeshProUGUI>().text = "Score: " + Score;
        if(!StopScore)
        {
            StartCoroutine(IncreaseScore());
        }
    }

    public void StopCounting()
    {
        StopScore = true;
    }

    public int GetScore()
    {
        return Score;
    }
}
