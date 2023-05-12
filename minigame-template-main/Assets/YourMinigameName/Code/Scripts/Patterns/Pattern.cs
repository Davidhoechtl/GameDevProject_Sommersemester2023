
namespace Assets.YourMinigameName.Code.Scripts.Patterns
{
    /// <summary>
    /// Abstract class that is the base for every pattern
    /// </summary>
    public abstract class Pattern
    {
        public abstract string Name { get; }

        /// <summary>
        /// Method for bool matrix generation
        /// </summary>
        public abstract bool[,] GetPatternMatrix();
    }
}
