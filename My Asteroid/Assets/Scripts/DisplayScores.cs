using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayScores : MonoBehaviour
{
    public void ShowScores()
    {
        SceneManager.LoadScene("ScoresScene", LoadSceneMode.Single);
    }
}
