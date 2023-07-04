using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private void Awake()
    {
        RankingInfo rankingInfo = DataSaver.loadData<RankingInfo>("RankingInfo");
    }

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
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Load Tutorial Scene");
    }

    public void QuitGame()
    {
        //Application.Quit();
        Debug.Log("Quit Game");
    }
}
