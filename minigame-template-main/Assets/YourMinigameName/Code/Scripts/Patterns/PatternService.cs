
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    internal class PatternService : IPatternService
    {
        public PatternService()
        {
            patterns = new List<Pattern>()
            {
                new EvenColumnPattern(),
                new UnevenColumnPattern(),
                new EvenRowPattern(),
                new UnevenRowPattern(),
                new CrossPattern(),
                new RandomPattern(),
            };
        }

        public bool[,] GetRandomPattern()
        {
            if (patterns.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, patterns.Count);
                Pattern chosenPattern = patterns[randomIndex];
                Debug.Log($"{chosenPattern.Name} was chosen");
                return chosenPattern.GetPatternMatrix();
            }
            else
            {
                throw new InvalidOperationException("There are no patterns to return");
            }
        }

        private readonly List<Pattern> patterns;
    }
}
