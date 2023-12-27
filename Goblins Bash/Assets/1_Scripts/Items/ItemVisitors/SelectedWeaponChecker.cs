using _1_Scripts.GameProgress;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Items.ItemVisitors
{
    public class SelectedWeaponChecker : IItemVisitor
    {
        private ProgressService _progressService;
        public bool IsSelected;

        public SelectedWeaponChecker(ProgressService progressService)
        {
            _progressService = progressService;
        }
        
        public void Visit(WeaponStaticData item) => Debug.Log("Передан предмет общего типа");

        public void Visit(MeleeWeaponStaticData meleeStaticData) =>
            IsSelected = _progressService.SelectedMeleeWeapon == meleeStaticData.TypeId;

        public void Visit(RangeWeaponStaticData rangeStaticData) =>
            IsSelected = _progressService.SelectedRangeWeapon == rangeStaticData.TypeId;

    }
}