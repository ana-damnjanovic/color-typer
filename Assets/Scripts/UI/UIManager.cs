using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject mainMenu;
    GameObject gameOverMenu;
    GameObject scoreDisplay;
    GameObject colorButtonUI;

    void Awake()
    {
        if (transform.childCount == 0)
        {
            InstantiateUI("Prefabs/UI/MainMenu", out mainMenu);
        }
        else
        {
            mainMenu = this.transform.GetChild(0).gameObject;
        }
        InstantiateUI("Prefabs/UI/GameOverMenu", out gameOverMenu);
        gameOverMenu.SetActive(false);
        InstantiateUI("Prefabs/UI/ScoreDisplay", out scoreDisplay);
        scoreDisplay.SetActive(false);
        InstantiateUI("Prefabs/UI/ColorButtonUI", out colorButtonUI);
        colorButtonUI.SetActive(false);

        GameStateManager.OnGameStateChanged += HandleUIChange;
    }

    void InstantiateUI(string path, out GameObject instance)
    {
        GameObject prefab = Resources.Load(path) as GameObject;
        instance = Instantiate(prefab);
        instance.transform.SetParent(transform, false);
    }

    void HandleUIChange(gameState newState)
    {
        if (newState == gameState.RUN)
        {
            mainMenu.SetActive(false);
            gameOverMenu.SetActive(false);
            scoreDisplay.SetActive(true);
            colorButtonUI.SetActive(true);
        }
        else if (newState == gameState.GAME_OVER)
        {
            mainMenu.SetActive(false);
            gameOverMenu.SetActive(true);
            scoreDisplay.SetActive(false);
            colorButtonUI.SetActive(false);
        }
    }
}
