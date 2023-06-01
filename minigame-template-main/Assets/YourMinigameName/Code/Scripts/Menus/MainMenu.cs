using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool canStartGame = false;

    public static MainMenu Instance { get; private set; }

    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one MainMenu");
        }
        else
        {
            Instance = this;
            canStartGame = false;
        }
    }

    private void Update()
    {
        if (PlayerConfigurationManager.Instance.GetPlayerConfigurations().Count <= 0)
        {
            canStartGame = false;
        }
        else
        {
            canStartGame = true;
        }
    }

    public void StartGame()
    {
        if (canStartGame)
        {
            Debug.Log("resuming game");
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            Debug.Log("No Players to play");
        }
    }
}
