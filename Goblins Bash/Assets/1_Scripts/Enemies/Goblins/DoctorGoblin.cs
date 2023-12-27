namespace _1_Scripts.Enemies.Goblins
{
    public class DoctorGoblin : Goblin, IStatusHandler
    {
        public StatusType StatusType { get; set; }

        protected override void FullChargeAction() => ActivateStatus();

        public  void ActivateStatus()
        {
            if(!level.Statuses.AddStatus(this))
                StartAttack();
        }

        public void OnStatusTriggered()
        {
            DeactivateStatus();
            chargeBar.ReduceChargeToDefault();
            chargeBar.StartCharging();
        }
        
        public void DeactivateStatus() => level.Statuses.RemoveStatus(StatusType);
    }
}