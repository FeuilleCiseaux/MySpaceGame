using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ScoresController : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    private void Start()
    {
        UpdateScores();
    }

    private void UpdateScores()
    {
        string scoreTxt = "";

        for (int i = 0; i < 5; i++)
        {
            int score = PlayerPrefs.GetInt("ScoreEntry" + i, 0);
            scoreTxt += (i + 1) + ". " + score + "\n";
        }

        highScore.text = scoreTxt;
    }
}
