using Assets.YourMinigameName.Code.Scripts;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public bool IsGameOver;
    public bool IsSinglePlayer;
    private bool isSetup = false;
    [SerializeField]
    private GameObject rankingInfo;
    private RankingInfo rankingInfoScript;
    private AudioSource backgroundMusic;

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
        rankingInfoScript = rankingInfo.GetComponent<RankingInfo>();

        backgroundMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        backgroundMusic.volume = PlayerConfigurationManager.Instance.musicVolume;

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
            rankingInfoScript.AddPlayer(controller.PlayerId, 1);
            Debug.Log("Player " + controller.PlayerId + " won!");
            controller.DeletePlayer();
        }

        if(winners.Count == 0)
        {
            Debug.Log("No one won!!");
        }

        SceneManager.LoadScene("GameOver");
    }
}