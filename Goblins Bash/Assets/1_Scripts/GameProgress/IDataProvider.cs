namespace _1_Scripts.GameProgress
{
    public interface IDataProvider
    {
        public bool TryLoad();
        public void Save();
    }
}