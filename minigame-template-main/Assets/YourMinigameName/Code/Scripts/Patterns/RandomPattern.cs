
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    using UnityEngine;
    internal class RandomPattern : Pattern
    {
        public override string Name => "Random Pattern";

        public override bool[,] GetPatternMatrix()
        {
            bool[,] matrix = new bool[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    matrix[x, y] = Random.Range(0, 4) % 2 == 0;
                }
            }

            return matrix;
        }
    }
}
