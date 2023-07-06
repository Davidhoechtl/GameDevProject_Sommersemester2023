using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class RankingInfo : MonoBehaviour
{
    public Dictionary<int, int> playerRankings;

    private void Start()
    {
        playerRankings = new Dictionary<int, int>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddPlayer(int id, int placement)
    {
        playerRankings.Add(id, placement);
        //playerCount--;
    }
}

