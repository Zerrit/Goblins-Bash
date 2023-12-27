using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    [CreateAssetMenu(fileName = "Range Attack Upgrade", menuName = "Create Upgrade/Range Attack Upgrade")]
    public class RangeAttackUpgrade : Upgrade
    {
        [field: SerializeField] private int increaseValue;
        
        public override void ApplyEffect(IPlayerController player)
        {
            player.WeaponController.RangeWeapon.HealthDamage += increaseValue;
        }
    }
}