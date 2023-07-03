using Assets.YourMinigameName.Code.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawnPoints;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private ParticleSystem spawnEffectPrefab1; // First spawn particle effect prefab
    [SerializeField]
    private ParticleSystem spawnEffectPrefab2; // Second spawn particle effect prefab

    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigurations().ToArray();

        for (int i = 0; i < playerConfigs.Length; ++i)
        {
            var player = Instantiate(playerPrefab, playerSpawnPoints[i].position, playerSpawnPoints[i].rotation, gameObject.transform);

            // Initialize the PlayerController
            var playerController = player.GetComponent<PlayerController>();
            playerController.InitializePlayer(playerConfigs[i]);

            Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f); // Adjust the rotation as needed
            Quaternion rotation2 = Quaternion.Euler(-47f, 0f, 0f); // Adjust the rotation as needed

            // Instantiate and play the first spawn effect particle system
            var spawnEffect1 = Instantiate(spawnEffectPrefab1, player.transform.position, rotation);
            spawnEffect1.Play();

            // Instantiate and play the second spawn effect particle system
            var spawnEffect2 = Instantiate(spawnEffectPrefab2, player.transform.position, rotation2);
            spawnEffect2.Play();

            // Disable player movement for 3 seconds
            playerController.GetComponent<PlayerController>().startDelay = true;
            StartCoroutine(EnablePlayerMovement(playerController, 2f));
        }
    }

    private IEnumerator EnablePlayerMovement(PlayerController playerController, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Enable player movement after the delay
        playerController.GetComponent<PlayerController>().startDelay = false;
    }
}
