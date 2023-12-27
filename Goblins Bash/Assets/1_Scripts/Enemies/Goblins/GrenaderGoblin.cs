namespace _1_Scripts.Enemies.Goblins
{
    public class GrenaderGoblin : Goblin
    {
        protected override void AfterAttackAction() => chargeBar.StartCharging();
    }
}