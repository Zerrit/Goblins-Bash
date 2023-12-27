namespace _1_Scripts.Enemies.Goblins
{
    public class ProvocatorGoblin : Goblin, IStatusHandler
    {
        public StatusType StatusType { get; set; }
        

        public void ActivateStatus() => level.Statuses.AddStatus(this);

        public void OnStatusTriggered()
        {
            blockFX.Play();
        }
        public void DeactivateStatus() => level.Statuses.RemoveStatus(StatusType);
    }
}