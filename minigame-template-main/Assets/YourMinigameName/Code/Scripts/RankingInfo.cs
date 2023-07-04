using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class RankingInfo
{
    public List<int> winnerIDs = new List<int>();

    public RankingInfo(List<int> playerList) 
    {
        winnerIDs = playerList;
    }
}

