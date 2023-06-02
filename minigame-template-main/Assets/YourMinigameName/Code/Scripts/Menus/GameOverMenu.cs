using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayTutorial()
    {
        //SceneManager.LoadScene(2);
        Debug.Log("Load Tutorial Scene");
    }

    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("Quit Game");
    }
}
