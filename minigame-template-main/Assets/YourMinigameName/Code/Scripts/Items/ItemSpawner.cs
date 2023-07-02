using Assets.YourMinigameName.Code.Scripts;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public KnockBackPowerup KnockBackPowerupPrefab;
    public GameGround GameGround;

    public float SpawnIntervalInSec = 15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        while (GameHandler.Instance.IsGameOver == false)
        {
            yield return new WaitForSeconds(SpawnIntervalInSec);

            // spawn item
            Instantiate(KnockBackPowerupPrefab, GetRandomPositionOnMap(), KnockBackPowerupPrefab.transform.rotation);
        }
    }

    private Vector3 GetRandomPositionOnMap()
    {
        MovingCube[,] map = GameGround.map;
        MovingCube randomCube = map[Random.Range(0, map.GetLength(0)), Random.Range(0, map.GetLength(1))];

        float powerupHeight = KnockBackPowerupPrefab.GetComponent<MeshRenderer>().bounds.size.y;

        // return the center point of randomCube
        return randomCube.transform.position + new Vector3(0, randomCube.GetComponent<MeshRenderer>().bounds.size.y / 2 + powerupHeight/2, 0);
    }
}
