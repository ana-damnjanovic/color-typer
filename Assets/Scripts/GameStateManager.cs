using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameState {
    SETUP, // show starting menu and initiate 3 second countdown if the player starts the game
    RUN, // gameplay
    GAME_OVER, // show game over UI
}

public class GameStateManager : MonoBehaviour
{
    private gameState currentState;
    public delegate void OnGameStateChangeHandler(gameState newState);
    public static event OnGameStateChangeHandler OnGameStateChanged;

    private static GameStateManager instance = null;

    public static GameStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject instanceObj = new GameObject();
                instance = instanceObj.AddComponent<GameStateManager>();
            }
            return instance;
        }

    }

    void Awake()
    {
        SetState(gameState.SETUP);
    }

    public gameState GetState()
    {
        return currentState;
    }

    public void SetState(gameState newState)
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
