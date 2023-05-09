
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    internal class UnevenColumnPattern : Pattern
    {
        public override string Name => "Uneven Row Pattern";

        public override bool[,] GetPatternMatrix()
        {
            return new bool[10, 10]
            {
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true },
                { false, true, false, true, false, true, false, true, false, true }
            };
        }
    }
}
