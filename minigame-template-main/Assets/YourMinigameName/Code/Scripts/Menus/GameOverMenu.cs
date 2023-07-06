using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private GameObject rankingInfo;
    private RankingInfo rankingInfoScript;
    public Dictionary<int, int> PlayerRankings;
    [SerializeField]
    private GameObject displayPlayerPrefab;
    [SerializeField]
    private GameObject rankingParent;
    [SerializeField]
    private GameObject YouLoseText;

    private void Awake()
    {
        YouLoseText.SetActive(false);
        rankingInfo = GameObject.Find("RankingInfo");
        PlayerRankings = rankingInfo.GetComponent<RankingInfo>().playerRankings.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        Destroy(rankingInfo);
        if(PlayerRankings.Count == 0)
        {
            YouLoseText.SetActive(true);
        }
        else
        {
            DisplayRanking();
        }
        
    }

    private void DisplayRanking()
    {
        foreach(var index in PlayerRankings)
        {
            GameObject player = Instantiate(displayPlayerPrefab, rankingParent.transform);
            player.GetComponent<DisplayPlayerRanking>().SetPlayerData(index.Key, index.Value);
        }
        
    }

    public void ReturnToMainMenu()
    {
        PlayerConfigurationManager.Instance.DestroyPlayerConfiguartionManager();
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
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
