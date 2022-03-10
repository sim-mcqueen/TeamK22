using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class DeathFade : MonoBehaviour
{
    public GameObject blackScreen;
    public float deltaColor;
    public string mainMenu;
    private float colorChange;
    private bool fadeToBlack;
    public int waitTime;
    private Bloom bloom;
    private DeathEvent deathEvent;
    private void Awake()
    {
        deathEvent = FindObjectOfType<DeathEvent>();
    }

    void Start()
    {
        colorChange = 0;
        deathEvent.OnDeath += DeathEvent_OnDeath;
    }

    private void DeathEvent_OnDeath(object sender, System.EventArgs e)
    {
        FindObjectOfType<KScoreText>().StopCounting();
        fadeToBlack = true;
        StartCoroutine(goToMainMenu());
    }

    // Update is called once per frame


    IEnumerator goToMainMenu()
    {
        yield return new WaitForSeconds(waitTime);
        GameManager.score = FindObjectOfType<KScoreText>().GetScore();
        SceneManager.LoadScene(mainMenu);

    }
}
