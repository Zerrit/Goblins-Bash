namespace _1_Scripts.StaticData
{
    public class StaticFormulas
    {
        public static int GetEnemyHealth(int lvl, int baseHealth) => baseHealth * lvl / 2;
        public static int GetEnemyDamage(int lvl, int baseDamage) => baseDamage + (lvl * 2);
    }
}