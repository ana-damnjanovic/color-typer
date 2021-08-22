using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int scoreMultiplier = 1;
    int score = 0;
    ScoreData highScoreData;
    int numTimesScored = 0;
    DataLoader loader = new DataLoader();

    public delegate void OnScoreChangedHandler(int newScore);
    public static event OnScoreChangedHandler OnScoreChanged;

    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        highScoreData = loader.LoadHighScore();
        GameStateManager.OnGameStateChanged += HandleGameStateChange;
        ColorBallManager.OnBallDestroyed += IncreaseScore;
    }

    void IncreaseMultiplier() {
        scoreMultiplier *= 2;
    }

    void IncreaseScore()
    {
        score += scoreMultiplier;
        numTimesScored++;
        if (numTimesScored % 6 == 0)
        {
            IncreaseMultiplier();
        }
        if (score > highScoreData.highScore)
        {
            highScoreData.highScore = score;
        }
        if (OnScoreChanged != null)
        {
            OnScoreChanged(score);
        }
    }


    void HandleGameStateChange(gameState newState)
    {
        if (newState == gameState.RUN)
        {
            OnScoreChanged(score);
        }
        if (newState == gameState.GAME_OVER)
        {
            score = 0;
            OnScoreChanged(0);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScoreData.highScore;
    }

    void OnApplicationQuit()
    {
        loader.SaveHighScore(highScoreData);
    }
}