
namespace Assets.YourMinigameName.Code.Scripts
{
    using Assets.YourMinigameName.Code.Scripts.DifficultySystem;
    using Assets.YourMinigameName.Code.Scripts.Patterns;
    using System.Collections;
    using UnityEngine;

    public class GameGround : MonoBehaviour, IHasDifficulty
    {
        /// <summary>
        /// GameObject that represents one tile of the game map
        /// </summary>
        public GameObject CubePrefab;

        /// <summary>
        /// Material that indicates the Cube is not going to move
        /// </summary>
        public Material StationaryMaterial;

        /// <summary>
        /// Material that indicated the cube is going to move
        /// </summary>
        public Material FallingMaterial;

        /// <summary>
        /// time between indication and falling in seconds at game start
        /// </summary>
        public float StartingWaitBeforeFallingTimeInSec = 2;

        /// <summary>
        /// Time between patterns in seconds at g ame start
        /// </summary>
        public float StartingWaitBetweenPatternInSec = 2;

        public float Difficulty { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            map = CreateGameGround();
            patternService = new PatternService();

            waitBetweenPatternInSec = StartingWaitBetweenPatternInSec;
            waitBeforeFallingTimeInSec = StartingWaitBeforeFallingTimeInSec;
            patternCoroutineFinished = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (patternCoroutineFinished)
            {
                StartCoroutine(ApplyPatternWithDelay(waitBetweenPatternInSec));
                patternCoroutineFinished = false;
            }
        }

        /// <summary>
        /// Starts the Pattern coroutine
        /// </summary>
        /// <param name="delayInSeconds"> time between patterns </param>
        /// <returns></returns>
        private IEnumerator ApplyPatternWithDelay(float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);

            ApplyMatrix(patternService.GetRandomPattern());

            while (!IsEveryCubeBackToNormal())
            {
                yield return new WaitForSeconds(0.3f);
            }

            patternCoroutineFinished = true;
        }

        /// <summary>
        /// Applies a 2-dimensional bool array on the 2-dimensional Map
        /// </summary>
        /// <param name="matrix"> generated bool matrix </param>
        /// <exception cref="System.InvalidOperationException"> thrown if the bool matrix does not fit the map matrix</exception>
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
                        MovingCube cube = map[x, y].GetComponent<MovingCube>();
                        StartCoroutine(cube.StartFalling(waitBeforeFallingTimeInSec));
                    }
                }
            }
        }

        /// <summary>
        /// Create Game Map (10x10 hardcoded)
        /// </summary>
        private MovingCube[,] CreateGameGround()
        {
            MovingCube[,] map = new MovingCube[10, 10];

            float margin = 0.02f;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Vector3 pos = new Vector3(x + (margin * x), 0, y + (margin * y));
                    GameObject item = Instantiate(CubePrefab, pos, CubePrefab.transform.rotation);
                    item.transform.parent = gameObject.transform;

                    MovingCube cube = item.AddComponent<MovingCube>();
                    cube.StationaryMaterial = StationaryMaterial;
                    cube.FallingMaterial = FallingMaterial;

                    map[x, y] = cube;
                }
            }

            gameObject.transform.localScale = new Vector3(5, 5, 5);

            return map;
        }

        /// <summary>
        /// Checks if every map element is back to its idle state. This needs to be checked before appling the next pattern
        /// </summary>
        /// <returns></returns>
        private bool IsEveryCubeBackToNormal()
        {
            bool finished = true;
            foreach (MovingCube cube in map)
            {
                if (!cube.IsIdle())
                {
                    finished = false;
                }
            }

            return finished;
        }

        public void RecalculateDifficulty(float passedTimeInSeconds)
        {
            Difficulty = passedTimeInSeconds / 10;
            waitBetweenPatternInSec = StartingWaitBetweenPatternInSec - Difficulty / 4;
            waitBeforeFallingTimeInSec = StartingWaitBeforeFallingTimeInSec - Difficulty / 2;
        }

        private float waitBetweenPatternInSec;
        private float waitBeforeFallingTimeInSec;
        private bool patternCoroutineFinished;

        private MovingCube[,] map;
        private PatternService patternService;

    }
}
