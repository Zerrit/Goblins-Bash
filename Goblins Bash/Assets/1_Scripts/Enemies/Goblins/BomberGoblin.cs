namespace _1_Scripts.Enemies.Goblins
{
    public class BomberGoblin : Goblin
    {
        public override void GetDamage(int healthDamage, int chargeDamage)
        {
            KnockBack(chargeDamage);
            Attack();
            Suicide();
        }

        protected override void FullChargeAction() => Suicide();

        private void Suicide()
        {
            impactFX.Play();
            healthBarBar.NullifyHealth();
            LeaveBattle();
        }
    }
}