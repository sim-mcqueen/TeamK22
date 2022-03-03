using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathFade : MonoBehaviour
{
    public GameObject blackScreen;
    public float deltaColor;
    public string mainMenu;
    private float colorChange;
    private bool fadeToBlack;
    public int waitTime;
    // Start is called before the first frame update
    void Start()
    {
        colorChange = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(fadeToBlack)
        {
            blackScreen.GetComponent<Image>().color = new Color(0f, 0f, 0f, colorChange);
            colorChange += deltaColor;
        }
    }


    public void StartDeath()
    {
        fadeToBlack = true;
        StartCoroutine(goToMainMenu());
    }


    IEnumerator goToMainMenu()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(mainMenu);

    }
}
