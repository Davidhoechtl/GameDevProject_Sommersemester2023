
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    /// <summary>
    /// Service that aggregates all patterns. This Service should be used for accessing pattern logic
    /// </summary>
    internal interface IPatternService
    {
        bool[,] GetRandomPattern();
    }
}
