using System.Collections;
using System.Collections.Generic;
using System.MulticastDelegate;
using UnityEngine;

public enum gameState {
    SETUP, // show starting menu and initiate 3 second countdown if the player starts the game
    RUN, // gameplay
    GAME_OVER, // show game over UI
}

public class GameStateManager : MonoBehaviour
{
    private gameState currentState;
    public delegate void OnGameStateChangeHandler(int newState);
    public static event OnGameStateChangeHandler OnGameStateChanged;

    private static GameStateManager instance = null;

    public static GameStateManager Instance
    {
        get
        {
            if (GameStateManager.instance == null)
            {
                GameStateManager.instance = new GameStateManager();
            }
            return GameStateManager.instance;
        }

    }

    void Awake()
    {
        SetState(SETUP);
    }

    public int GetState()
    {
        return currentState;
    }

    public void SetState(int newState)
    {
        currentState = newState;
        if (OnGameStateChanged != null)
        {
            OnGameStateChanged(newState);
        }

    }

    void OnApplicationQuit()
    {
        GameStateManager.instance = null;
    }
}
