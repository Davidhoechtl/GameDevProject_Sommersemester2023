
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    internal class UnevenRowPattern : Pattern
    {
        public override string Name => "Uneven Row Pattern";

        public override bool[,] GetPatternMatrix()
        {
            return new bool[10, 10]
            {
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true },
                { false, false, false, false, false, false, false, false, false, false },
                { true, true, true, true, false, true, true, true, true, true }
            };
        }
    }
}
