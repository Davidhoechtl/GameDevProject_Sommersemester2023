using Assets.YourMinigameName.Code.Scripts;
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
        List<PlayerConfiguration> winners = new List<PlayerConfiguration>();
        //Debug.Log(players.Length + "  " + IsSinglePlayer);

        if (players.Length <= 1 && !IsSinglePlayer)
        {
            IsGameOver = true;
            LoadGameOverScreen(players);
        }

        if (players.Length <= 0 && IsSinglePlayer)
        {
            IsGameOver = true;
            LoadGameOverScreen(players);
        }
    }

    public void TimerUp()
    {
        IsGameOver = true;
        LoadGameOverScreen(GameObject.FindGameObjectsWithTag("Player"));
    }

    public void LoadGameOverScreen(GameObject[] players)
    {
        List<int> winners = new List<int>();

        for (int i = 0; i < players.Length; i++)
        {
            PlayerController controller = players[i].gameObject.GetComponent<PlayerController>();
            winners.Add(controller.PlayerId);
            Debug.Log("Player " + controller.PlayerId + " won!");
            controller.DeletePlayer();
        }

        if(winners.Count == 0)
        {
            Debug.Log("No one won!!");
        }

        RankingInfo ranking = new RankingInfo(winners);
        DataSaver.saveData(ranking, "RankingInfo");

        SceneManager.LoadScene("GameOver");
    }
}