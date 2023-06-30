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
    [SerializeField]
    private ParticleSystem[] spawnEffectPrefabs; // Array of spawn particle effect prefabs

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigurations().ToArray();

        for (int i = 0; i < playerConfigs.Length; ++i)
        {
            var player = Instantiate(playerPrefab, playerSpawnPoints[i].position, playerSpawnPoints[i].rotation, gameObject.transform);

            // Initialize the PlayerController
            player.GetComponent<PlayerController>().InitializePlayer(playerConfigs[i]);

            for (int j = 0; j < spawnEffectPrefabs.Length; j++)
            {
                // Instantiate the spawn effect particle system prefab
                var spawnEffect = Instantiate(spawnEffectPrefabs[j], player.transform.position, Quaternion.identity);

                // Play the spawn effect particle system
                spawnEffect.Play();
            }
        }
    }
}