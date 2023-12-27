using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    [CreateAssetMenu(fileName = "Melee Attack Upgrade", menuName = "Create Upgrade/Melee Attack Upgrade")]
    public class MeleeAttackUpgrade : Upgrade
    {
        [field: SerializeField] private int increaseValue;
        
        public override void ApplyEffect(IPlayerController player)
        {
            player.WeaponController.MeleeWeapon.HealthDamage += increaseValue;
        }
    }
}