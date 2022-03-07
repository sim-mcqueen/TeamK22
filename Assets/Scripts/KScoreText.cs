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

    private void Awake()
    {
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
        if(Score % 50 == 0)
        {
            if(eventActive)
            {
                if(num == 0)
                {
                    gravityEvent.ChangeGravity();
                }
                eventActive = false;
            }
            else
            {
                eventActive = true;
                // num = Random.Range(0, 0);
                num = 0;
                if (num == 0)
                {
                    gravityEvent.ChangeGravity();
                }
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
