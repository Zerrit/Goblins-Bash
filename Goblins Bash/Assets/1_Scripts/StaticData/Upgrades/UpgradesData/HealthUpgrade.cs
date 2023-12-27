using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    [CreateAssetMenu(fileName = "Health Upgrade", menuName = "Create Upgrade/Health Upgrade")]
    public class HealthUpgrade : Upgrade
    {
        [field: SerializeField] private int changeValue;
        
        public override void ApplyEffect(IPlayerController player)
        {
            player.PlayerHealth.ChangeMaxHealth(changeValue);
        }
    }
}