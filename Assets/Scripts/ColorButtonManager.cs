using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonManager : MonoBehaviour
{
    List<ColorBall> colorBalls;
    List<ColorButtonBehaviour> buttonBehaviours;
    bool assigned = false;

    void Awake()
    {
        ColorButtonBehaviour.OnColorButtonClick += HandleColorButtonClick;
        GameStateManager.OnGameStateChanged += HandleGameStateChange;
        MainMenuManager.OnPlayerPrefChanged += CopyColorBalls;
        buttonBehaviours = new List<ColorButtonBehaviour>(transform.GetComponentsInChildren<ColorButtonBehaviour>());
    }

    void Start()
    {
        CopyColorBalls();
    }

    void CopyColorBalls()
    {
        colorBalls = ColorBallManager.Instance.GetPossibleColorBalls();
    }

    void Update()
    {
        if (!assigned)
        {
            AssignButtonColors();
        }
    }

    void HandleColorButtonClick(string buttonColor)
    {
        ColorBall frontBall = ColorBallManager.Instance.GetFrontBall();
        if (frontBall != null)
        {
            if (frontBall.GetColor() == buttonColor)
            {
                ColorBallManager.Instance.DestroyFrontBall();
                assigned = false;
            }
        }
    }

    void HandleGameStateChange(gameState newState)
    {
        if (newState == gameState.RUN)
        {
            assigned = false;
        }
    }

    void AssignButtonColors()
    {
        ColorBall frontBall = ColorBallManager.Instance.GetFrontBall();
        if (frontBall == null)
        {
            assigned = false;
            return;
        }
        List<ColorBall> remainingColorBalls = new List<ColorBall>(colorBalls); // use the color balls to pick random button colors from
        int correctIndex = Random.Range(0, buttonBehaviours.Count);
        ColorButtonBehaviour correctButton = buttonBehaviours[correctIndex];
        List<ColorButtonBehaviour> wrongButtons = new List<ColorButtonBehaviour>(buttonBehaviours);
        wrongButtons.RemoveAt(correctIndex);
        correctButton.SetColor(frontBall.GetColor());
        correctButton.SetMaterial(frontBall.GetMaterial());
        if (PlayerPrefs.GetInt("DisplayShapes", 0) == 1)
        {
            correctButton.SetTexture(frontBall.GetTexture());
        }
        RemoveMatchingColorBalls(frontBall.GetColor(), remainingColorBalls); // ensure that we don't accidentally make two "correct" buttons
        foreach (ColorButtonBehaviour button in wrongButtons)
        {
            int i = Random.Range(0, remainingColorBalls.Count);
            button.SetColor(remainingColorBalls[i].GetColor());
            button.SetMaterial(remainingColorBalls[i].GetMaterial());
            if (PlayerPrefs.GetInt("DisplayShapes", 0) == 1)
            {
                button.SetTexture(remainingColorBalls[i].GetTexture());
            }
            remainingColorBalls.RemoveAt(i);
        }
        assigned = true;
    }

    void RemoveMatchingColorBalls(string color, List<ColorBall> colorBalls)
    {
        for (int i = 0; i < colorBalls.Count; i++)
        {
            if (colorBalls[i].GetColor() == color)
            {
                colorBalls.RemoveAt(i);
                break;
            }
        }
        
    }
}
