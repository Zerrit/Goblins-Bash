using System.Collections.Generic;
using _1_Scripts.StaticData;

namespace _1_Scripts.GameProgress
{
    public interface IProgressService
    {
        MeleeWeaponType SelectedMeleeWeapon { get; }
        RangeWeaponType SelectedRangeWeapon { get; }
        int SelectedMeleeWeaponLevel { get; }
        int SelectedRangeWeaponLevel { get; }
        IReadOnlyDictionary<MeleeWeaponType, int> PurchasedMeleeWeapons { get; }
        IReadOnlyDictionary<RangeWeaponType, int> PurchasedRangeWeapons { get; }
        int CountAvailableCells { get; }
        IReadOnlyList<ArtifactsType> SelectedArtifacts { get; }
        IEnumerable<ArtifactsType> PurchasedArtifacts { get; }
        void SelectMeleeWeapon(MeleeWeaponType meleeWeaponType);
        void SelectRangeWeapon(RangeWeaponType rangeWeaponType);
        void PurchaseMeleeWeapon(MeleeWeaponType weapon);
        void PurchaseRangeWeapon(RangeWeaponType weapon);
        void UpgradeMeleeWeapon(MeleeWeaponType weapon);
        void UpgradeRangeWeapon(RangeWeaponType weapon);
        void UnlockArtefactCell();
        void UpdateArtifacts(IReadOnlyList<ArtifactsType> artifacts);
    }
}