using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    public void OnClickPlay()
    {
        GameStateManager.Instance.SetState(gameState.RUN);
    }
}
