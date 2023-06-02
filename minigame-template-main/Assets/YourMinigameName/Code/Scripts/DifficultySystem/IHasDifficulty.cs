namespace Assets.YourMinigameName.Code.Scripts.DifficultySystem
{
    public interface IHasDifficulty
    {
        public float Difficulty { get; }
        void RecalculateDifficulty(float passedTimeInSeconds);
    }
}
