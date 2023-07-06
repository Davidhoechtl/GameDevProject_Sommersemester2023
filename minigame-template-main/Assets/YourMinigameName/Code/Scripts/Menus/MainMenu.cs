using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool canStartGame = false;
    public static MainMenu Instance { get; private set; }

    public GameObject ui;
    public GameObject credits;

    public bool ignoreFirstInput = true;

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
        if (canStartGame && !ignoreFirstInput)
        {
            Debug.Log("resuming game");
            SceneManager.LoadScene("MainGame");
        } 
        else if (canStartGame && ignoreFirstInput)
        {
            ignoreFirstInput = false;
        }
        else
        {
            Debug.Log("No Players to play");
        }
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartCredits()
    {
        StartCoroutine(SmallDelay());
        StartCoroutine(PlayCredits());
    }

    IEnumerator SmallDelay() // to let the click-sound play
    {
        yield return new WaitForSeconds(0.1f);
        ui.SetActive(false);
        credits.SetActive(true);
    }

    IEnumerator PlayCredits()
    {
        yield return new WaitForSeconds(28); // duration of credits animation 

        ui.SetActive(true);
        credits.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
    }
}