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


    private void Awake()
    {
        DE = GetComponent<DeathEvent>();
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
