using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    GameObject mainMenu;
    GameObject optionsMenu;
    int shouldDisplayShapes;
    Toggle displayShapesToggle;


    public delegate void PlayerPrefChangeHandler();
    public static PlayerPrefChangeHandler OnPlayerPrefChanged;

    void Awake()
    {
        mainMenu = transform.Find("MainMenu").gameObject;
        optionsMenu = transform.Find("OptionsMenu").gameObject;
        shouldDisplayShapes = PlayerPrefs.GetInt("DisplayShapes", 0);
        displayShapesToggle = transform.GetComponentInChildren<Toggle>();
        if (shouldDisplayShapes == 1)
        {
            displayShapesToggle.isOn = true;
        }
        else
        {
            displayShapesToggle.isOn = false;
        }
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        displayShapesToggle.onValueChanged.AddListener(delegate {
            OnToggleValueChanged(displayShapesToggle);
        });
    }
    public void OnClickPlay()
    {
        GameStateManager.Instance.SetState(gameState.RUN);
    }

    public void OnClickOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OnClickBack()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    void OnToggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("DisplayShapes", 1);
        }
        else
        {
            PlayerPrefs.SetInt("DisplayShapes", 0);
        }
        if (OnPlayerPrefChanged != null)
        {
            OnPlayerPrefChanged();
        }
    }
}
