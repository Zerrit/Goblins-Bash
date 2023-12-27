using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    [CreateAssetMenu(fileName = "Health Restore", menuName = "Create Upgrade/Health Restore")]
    public class HealthRestore : Upgrade
    {
        [Header("Значение является неправильной дробью")]
        [field: SerializeField] private float healPercentage;
        
        public override void ApplyEffect(IPlayerController player)
        {
            player.PlayerHealth.IncreaseHealthByPercentage(healPercentage);
        }
    }
}