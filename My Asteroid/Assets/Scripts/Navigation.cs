using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public void ShowCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void ShowMenu() 
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void ShowScores()
    {
        SceneManager.LoadScene("ScoresScene", LoadSceneMode.Single);
    }

}
