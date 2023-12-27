using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    [CreateAssetMenu(fileName = "Melee Attack Speed Upgrade", menuName = "Create Upgrade/Melee Attack Speed Upgrade")]
    public class MeleeAttackSpeedUpgrade : Upgrade
    {
        [Header("Числовая прибавка к множителю скорости")]
        [field: SerializeField] private float increaseValue;
        
        public override void ApplyEffect(IPlayerController player)
        {
            player.WeaponController.MeleeWeapon.AttackSpeed += increaseValue;
        }
    }
}