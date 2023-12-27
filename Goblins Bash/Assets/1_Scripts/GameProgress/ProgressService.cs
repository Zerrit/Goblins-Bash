using System;
using System.Collections.Generic;
using _1_Scripts.Items;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.GameProgress
{
    public class ProgressService : IProgressService
    {
        private readonly IPersistentData _persistendData;
        private readonly IDataProvider _dataProvider;
        
        
        public ProgressService(IPersistentData persistentData, IDataProvider dataProvider)
        {
            _persistendData = persistentData;
            _dataProvider = dataProvider;
        }
        
        
        // MANIPULATION WITH SELECTED WEAPONS
        public MeleeWeaponType SelectedMeleeWeapon => _persistendData.Progress.selectedMeleeWeapon;
        public RangeWeaponType SelectedRangeWeapon => _persistendData.Progress.selectedRangeWeapon;

        public void SelectMeleeWeapon(MeleeWeaponType meleeWeaponType)
        {
            if(_persistendData.Progress.purchasedMeleeWeapons.ContainsKey(meleeWeaponType))
                _persistendData.Progress.selectedMeleeWeapon = meleeWeaponType;
            else Debug.LogWarning("Совершена попытка выбора ещё не приобретенного оружия! :" + meleeWeaponType);
        }
        public void SelectRangeWeapon(RangeWeaponType rangeWeaponType)
        {
            if(_persistendData.Progress.purchasedRangeWeapons.ContainsKey(rangeWeaponType))
                _persistendData.Progress.selectedRangeWeapon = rangeWeaponType;
            else Debug.LogWarning("Совершена попытка выбора ещё не приобретенного оружия! :" + rangeWeaponType);
        }
        
        // УРОВЕНЬ ВЫБРАННОГО ОРУЖИЯ
        public int SelectedMeleeWeaponLevel => PurchasedMeleeWeapons[SelectedMeleeWeapon];
        public int SelectedRangeWeaponLevel => PurchasedRangeWeapons[SelectedRangeWeapon];


        
        
        
        // MANIPULATION WITH PURCHASED WEAPONS
        public IReadOnlyDictionary<MeleeWeaponType, int> PurchasedMeleeWeapons => _persistendData.Progress.purchasedMeleeWeapons;
        public IReadOnlyDictionary<RangeWeaponType, int> PurchasedRangeWeapons => _persistendData.Progress.purchasedRangeWeapons;

        // BUY WEAPONS
        public void PurchaseMeleeWeapon(MeleeWeaponType weapon)
        {
            if (_persistendData.Progress.purchasedMeleeWeapons.ContainsKey(weapon))
                _persistendData.Progress.purchasedMeleeWeapons.Add(weapon, 1);
            else Debug.LogWarning("Совершена попытка приобрести уже имющееся оружие:" + weapon);
        }
        public void PurchaseRangeWeapon(RangeWeaponType weapon)
        {
            if (_persistendData.Progress.purchasedRangeWeapons.ContainsKey(weapon))
                _persistendData.Progress.purchasedRangeWeapons.Add(weapon, 1);
            else Debug.LogWarning("Совершена попытка приобрести уже имющееся оружие:" + weapon);
        }
        
        // UPGRADE WEAPONS
        public void UpgradeMeleeWeapon(MeleeWeaponType weapon)
        {
            if (_persistendData.Progress.purchasedMeleeWeapons.ContainsKey(weapon))
                _persistendData.Progress.purchasedMeleeWeapons[weapon]++;
            else Debug.LogWarning("Совершена попытка улучшить не имющееся в наличии оружие: "+ weapon);            
        }
        public void UpgradeRangeWeapon(RangeWeaponType weapon)
        {
            if (_persistendData.Progress.purchasedRangeWeapons.ContainsKey(weapon))
                _persistendData.Progress.purchasedRangeWeapons[weapon]++;
            else Debug.LogWarning("Совершена попытка улучшить не имющееся в наличии оружие: "+ weapon); 
        }

        
        
        // MANIPULATION WITH ARTIFACTS
        public int CountAvailableCells => _persistendData.Progress.countArtifactCells;
        
        public void UnlockArtefactCell()
        {
            if (CountAvailableCells < 3) _persistendData.Progress.countArtifactCells++;
        }
        
        
        public IReadOnlyList<ArtifactsType> SelectedArtifacts => _persistendData.Progress.selectedArtifacts;

        public void UpdateArtifacts(IReadOnlyList<ArtifactsType> artifacts)
        {
            for (int i = 0; i < 3; i++)
            {
                _persistendData.Progress.selectedArtifacts[i] = artifacts[i];
            }
        }

        public IEnumerable<ArtifactsType> PurchasedArtifacts => _persistendData.Progress.purchasedArtifacts;

    }
}