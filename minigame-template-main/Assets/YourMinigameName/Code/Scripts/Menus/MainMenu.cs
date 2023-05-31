using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int playerCount = 0;
    public Button start_Game_Button;

    private bool canStartGame = false;

    public static MainMenu Instance { get; private set; }

    private void Start()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple Instances of MainMenu");

        }
        Instance = this;
    }

    private void Update()
    {
        if (playerCount <= 0)
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
            PlayerPrefs.SetInt("playerCount", playerCount);

            Debug.Log("resuming game");
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("No Players to play");
        }
    }

    public void IncreasePlayerCount()
    {
        playerCount++;
    }

    public void DecreasePlayerCount()
    {
        playerCount--;
    }
}
