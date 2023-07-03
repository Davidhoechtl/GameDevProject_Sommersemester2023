using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameHandler : MonoBehaviour
{
    public bool IsGameOver;
    public bool IsSinglePlayer;
    private bool isSetup = false;

    public static GameHandler Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("The Singleton GameHandler is null");
            }

            return instance;
        }
    }

    private static GameHandler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Setup();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(this);
    }

    public void Setup()
    {
        instance.IsGameOver = false;

        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            instance.IsSinglePlayer = true;
        }
        else
        {
            instance.IsSinglePlayer = false;
        }
        isSetup = true;
        //Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length + "  " + instance.IsSinglePlayer);
    }

    private void FixedUpdate()
    {
        if(isSetup)
        {
            CheckIfGameOver();
        }
    }

    public void CheckIfGameOver()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(players.Length + "  " + IsSinglePlayer);

        if (players.Length <= 1 && !IsSinglePlayer)
        {
            IsGameOver = true;
            SceneManager.LoadScene("GameOver");
        }

        if (players.Length <= 0 && IsSinglePlayer)
        {
            IsGameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}