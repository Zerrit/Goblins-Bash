using _1_Scripts.GameProgress;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Items.ItemVisitors
{
    public class WeaponUpgradeLevelChecker : IItemVisitor
    {
        private ProgressService _progressService;
        public int WeaponLevel;

        public WeaponUpgradeLevelChecker(ProgressService progressService)
        {
            _progressService = progressService;
        }
        
        public void Visit(WeaponStaticData item) => Debug.Log("Передан предмет общего типа");

        public void Visit(MeleeWeaponStaticData meleeStaticData) =>
            WeaponLevel = _progressService.PurchasedMeleeWeapons[meleeStaticData.TypeId];

        public void Visit(RangeWeaponStaticData rangeStaticData) =>
            WeaponLevel = _progressService.PurchasedRangeWeapons[rangeStaticData.TypeId];

    }
}