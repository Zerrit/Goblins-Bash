namespace _1_Scripts.Logic
{
    public interface ILevelsCreator
    {
        public Level CurrentLevel { get; }
        void CreateStartLevel();
        void CreateNextLevel();
    }
}