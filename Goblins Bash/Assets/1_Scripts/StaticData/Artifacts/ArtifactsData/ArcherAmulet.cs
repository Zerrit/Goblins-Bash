using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Items.Artifacts
{
    [CreateAssetMenu(fileName = "Archer Amulet", menuName = "Create Artifacts/ArcherAmulet")]
    public class ArcherAmulet : Artifact
    {
        [SerializeField] private int newDamageValue;
        
        public override void ApplyEffect(ArtifactSystem artifactSystem)
        {
            artifactSystem.Player.WeaponController.RangeWeapon.ChargeDamage = 0;
            artifactSystem.Player.WeaponController.RangeWeapon.HealthDamage *= newDamageValue;
        }
    }
}