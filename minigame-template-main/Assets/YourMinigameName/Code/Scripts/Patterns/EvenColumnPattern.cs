
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    internal class EvenColumnPattern : Pattern
    {
        public override string Name => "Even Row Pattern";

        public override bool[,] GetPatternMatrix()
        {
            return new bool[10, 10]
            {
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false },
                { true, false, true, false, true, false, true, false, true, false }
            };
        }
    }
}
