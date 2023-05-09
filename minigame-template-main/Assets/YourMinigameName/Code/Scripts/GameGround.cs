using Assets.YourMinigameName.Code.Scripts.Patterns;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameGround : MonoBehaviour
{
    public GameObject CubePrefab;
    public Material AcitvatedMaterial;
    public Material NormalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        map = CreateGameGround();
        patternService = new PatternService();

        StartCoroutine(ApplyPatternWithDelay(2));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator ApplyPatternWithDelay(int delayInSeconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(delayInSeconds);
            ApplyMatrix(patternService.GetRandomPattern());
        }
    }

    private void ApplyMatrix(bool[,] matrix)
    {
        if (matrix.GetUpperBound(0) != map.GetUpperBound(0) || matrix.GetUpperBound(1) != map.GetUpperBound(1))
        {
            throw new System.InvalidOperationException("The matrix has not the correct size to match the map");
        }

        for (int x = 0; x <= matrix.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= matrix.GetUpperBound(1); y++)
            {
                if (matrix[x, y])
                {
                    StartCoroutine(ActivateForFalling(map[x, y]));
                }
            }
        }
    }

    private IEnumerator ActivateForFalling(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material = AcitvatedMaterial;
        yield return new WaitForSeconds(1);
        obj.GetComponent<MeshRenderer>().material = NormalMaterial;
    }

    private GameObject[,] CreateGameGround()
    {
        GameObject[,] map = new GameObject[10, 10];

        float margin = 0.02f;
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Vector3 pos = new Vector3(x + (margin * x), 0, y + (margin * y));
                GameObject item = Instantiate(CubePrefab, pos, CubePrefab.transform.rotation);
                item.transform.parent = gameObject.transform;
                map[x, y] = item;
            }
        }

        gameObject.transform.localScale = new Vector3(5, 5, 5);

        return map;
    }

    private GameObject[,] map;
    private PatternService patternService;
}
