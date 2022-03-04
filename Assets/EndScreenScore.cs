using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenScore : MonoBehaviour
{
    public GameObject HighScoreText;
    public GameObject ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + GameManager.score;
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(GameManager.score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", GameManager.score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", GameManager.score);
        }
        HighScoreText.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
