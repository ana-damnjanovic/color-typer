using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenuManager : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI highScoreText;

    void Awake()
    {
        Transform panel = transform.Find("Panel");
        scoreText = panel.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        highScoreText = panel.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        GameStateManager.OnGameStateChanged += HandleGameStateChange;
    }
    public void OnClickPlayAgain()
    {
        GameStateManager.Instance.SetState(gameState.RUN);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    void HandleGameStateChange(gameState newState)
    {
        if (newState == gameState.GAME_OVER)
        {
            scoreText.SetText("Your Score: " + ScoreManager.Instance.GetScore());
            highScoreText.SetText("High Score: " + ScoreManager.Instance.GetHighScore());
        }
    }
}
