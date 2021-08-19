using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuBehaviour : MonoBehaviour
{
    public void OnClickPlayAgain()
    {
        GameStateManager.Instance.SetState(gameState.RUN);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
