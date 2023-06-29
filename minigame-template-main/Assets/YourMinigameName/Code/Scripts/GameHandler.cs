using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameHandler : MonoBehaviour
{
    public bool IsGameOver;
    public bool IsSinglePlayer;
    public static GameHandler Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null) 
        {
            Debug.LogError("Multiple instances of GameHandler");
        }
        else
        {
            Instance = this;
            IsGameOver = false;

            if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
            {
                IsSinglePlayer = true;
            }
            else
            {
                IsSinglePlayer = false;
            }
        }
        Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length + "  " + IsSinglePlayer);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length + "  " + IsSinglePlayer);
    }

   /* private void FixedUpdate()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length + "  " + IsSinglePlayer);

        if (players.Length == 1 && !IsSinglePlayer)
        {
            IsGameOver = true;
            SceneManager.LoadScene("GameOver");
        }

        if (players.Length == 0 && IsSinglePlayer)
        {
            IsGameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    */

    public void CheckIfGameOver()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length + "  " + IsSinglePlayer);

        if(players.Length == 1 && !IsSinglePlayer) 
        {
            IsGameOver = true;
            SceneManager.LoadScene("GameOver");
        }

        if(players.Length == 0 && IsSinglePlayer)
        {
            IsGameOver = true;
            SceneManager.LoadScene("GameOver");
        }
    }
}
