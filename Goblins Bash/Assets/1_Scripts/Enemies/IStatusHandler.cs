namespace _1_Scripts.Enemies
{
    public interface IStatusHandler
    {
        public StatusType StatusType { get; set; }

        public void OnStatusTriggered();
        public void ActivateStatus();
        public void DeactivateStatus();
    }
}