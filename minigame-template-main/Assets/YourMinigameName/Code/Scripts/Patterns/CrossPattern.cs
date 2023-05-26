
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    internal class CrossPattern : Pattern
    {
        public override string Name => "Cross Pattern";

        public override bool[,] GetPatternMatrix()
        {
            return new bool[10, 10]
            {
                { true, false, false, false, false, false, false, false, false, true },
                { false, true, false, false, false, false, false, false, true, false },
                { false, false, true, false, false, false, false, true, false, false },
                { false, false, false, true, false, false, true, false, false, false },
                { false, false, false, false, true, true, false, false, false, false },
                { false, false, false, false, true, true, false, false, false, false },
                { false, false, false, true, false, false, true, false, false, false },
                { false, false, true, false, false, false, false, true, false, false },
                { false, true, false, false, false, false, false, false, true, false },
                { true, false, false, false, false, false, false, false, false, true }
            };
        }
    }
}
