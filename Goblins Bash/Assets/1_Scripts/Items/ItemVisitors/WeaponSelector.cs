using _1_Scripts.GameProgress;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Items.ItemVisitors
{
    public class WeaponSelector : IItemVisitor
    {
        private ProgressService _progressService;

        public WeaponSelector(ProgressService progressService)
        {
            _progressService = progressService;
        }

        public void Visit(WeaponStaticData item) => Debug.Log("Передан предмет общего типа");

        public void Visit(MeleeWeaponStaticData meleeStaticData) => _progressService.SelectMeleeWeapon(meleeStaticData.TypeId);

        public void Visit(RangeWeaponStaticData rangeStaticData) => _progressService.SelectRangeWeapon(rangeStaticData.TypeId);

    }
}