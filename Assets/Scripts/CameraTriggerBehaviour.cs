using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Ball"))
        {
            GameStateManager.Instance.SetState(gameState.GAME_OVER);
            Destroy(other.gameObject);
        }
    }
}
