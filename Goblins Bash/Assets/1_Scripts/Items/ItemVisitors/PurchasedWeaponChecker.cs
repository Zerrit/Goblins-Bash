using System.Linq;
using _1_Scripts.GameProgress;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Items.ItemVisitors
{
    public class PurchasedWeaponChecker : IItemVisitor
    {
        private readonly ProgressService _progressService;
        public bool IsPurchaised;

        public PurchasedWeaponChecker(ProgressService progressService)
        {
            _progressService = progressService;
        }
        
        public void Visit(WeaponStaticData item) => Debug.Log("Передан предмет общего типа");

        public void Visit(MeleeWeaponStaticData meleeStaticData) =>
            IsPurchaised = _progressService.PurchasedMeleeWeapons.ContainsKey(meleeStaticData.TypeId);
        
        public void Visit(RangeWeaponStaticData rangeStaticData) => 
            IsPurchaised = _progressService.PurchasedRangeWeapons.ContainsKey(rangeStaticData.TypeId);

    }
}