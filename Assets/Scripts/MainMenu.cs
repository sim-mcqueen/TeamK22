using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string playScene;
    public GameObject menuCanvas;
    public GameObject optionsCanvas;

    public void PlayButton()
    {
        SceneManager.LoadScene(playScene);
    }

    public void OptionsButton()
    {
        optionsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void BackButton()
    {
        optionsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
