using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayBehaviour : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    void Awake()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        ScoreManager.OnScoreChanged += RefreshScoreDisplay;
    }

    void RefreshScoreDisplay(int newScore)
    {
        scoreText.SetText("Score: " + newScore.ToString());
    }
}
