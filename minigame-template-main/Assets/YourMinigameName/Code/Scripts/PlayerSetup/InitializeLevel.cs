using Assets.YourMinigameName.Code.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawnPoints;
    [SerializeField]
    private GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigurations().ToArray();

        for(int i = 0; i < playerConfigs.Length; ++i)
        {
            var player = Instantiate(playerPrefab, playerSpawnPoints[i].position, playerSpawnPoints[i].rotation, gameObject.transform);
            player.GetComponent<PlayerController>().InitializePlayer(playerConfigs[i]);
            
        }
    }

}
