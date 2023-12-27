using _1_Scripts.GameProgress;
using _1_Scripts.Items;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.WeaponsLogic
{
    public class WeaponsFactory
    {
        private readonly ProgressService _progressService;
        private readonly IStaticDataService _staticDataService;


        public WeaponsFactory(IStaticDataService staticData, ProgressService progressService)
        {
            _staticDataService = staticData;
            _progressService = progressService;
        }

        public MeleeWeapon GetMeleeWeapon()
        {
            MeleeWeaponStaticData staticData = _staticDataService.GetDataFor(_progressService.SelectedMeleeWeapon);
            MeleeWeapon weapon = Object.Instantiate(staticData.Prefab).GetComponent<MeleeWeapon>();
            weapon.Initialize(staticData.HealthDamage, staticData.ChargeDamage, staticData.AttaskSpeed);
            return weapon;
        }

        public RangeWeapon GetRangeWeapon()
        {
            RangeWeaponStaticData staticData = _staticDataService.GetDataFor(_progressService.SelectedRangeWeapon);
            RangeWeapon weapon = Object.Instantiate(staticData.Prefab).GetComponent<RangeWeapon>();
            weapon.Initialize(staticData.HealthDamage, staticData.ChargeDamage, staticData.MaxProjectileCount,
                staticData.MaxProjectileCount, staticData.ProjectileCooldown);
            
            return weapon;
        }
        
    }
}