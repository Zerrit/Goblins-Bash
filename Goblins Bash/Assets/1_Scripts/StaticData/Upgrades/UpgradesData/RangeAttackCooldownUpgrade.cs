using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    [CreateAssetMenu(fileName = "Range Attack Cooldown Upgrade", menuName = "Create Upgrade/Range Attack Cooldown Upgrade")]
    public class RangeAttackCooldownUpgrade : Upgrade
    {
        [Header("Значение на которое уменьшится перезарядка")]
        [field: SerializeField] private float reduceValue;
        
        public override void ApplyEffect(IPlayerController player)
        {
            //player.WeaponController.RangeWeapon.ProjectileCooldown -= reduceValue;
        }
    }
}