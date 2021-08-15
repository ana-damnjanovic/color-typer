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
    public delegate void OnGameStateChanged(int newState);
    public static event OnGameStateChanged onGameStateChanged;

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
        if (onGameStateChanged != null)
        {
            onGameStateChanged(newState);
        }

    }
}
