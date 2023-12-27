using System.Collections.Generic;
using System.Linq;
using _1_Scripts.Items;
using _1_Scripts.StaticData;
using Newtonsoft.Json;

namespace _1_Scripts.GameProgress
{
    public class PlayerProgress
    {
        public int money;

        // ВЫБРАННОЕ ОРУЖИЕ
        public MeleeWeaponType selectedMeleeWeapon;
        public RangeWeaponType selectedRangeWeapon;
        
        // ИМЕЮЩЕЕСЯ ОРУЖИЕ
        public Dictionary<MeleeWeaponType, int> purchasedMeleeWeapons;
        public Dictionary<RangeWeaponType, int> purchasedRangeWeapons;

        // КОЛИЧЕСТВО ДОСТУПНЫХ ЯЧЕЕК АРТЕФАКТОВ
        public int countArtifactCells;

        // ВЫБРАННЫЕ АРТЕФАКТЫ
        public ArtifactsType[] selectedArtifacts;
        
        // ИМЕЮЩИЕСЯ АРТЕФАКТЫ
        public List<ArtifactsType> purchasedArtifacts;
        
        
        public PlayerProgress()
        {
            money = 0;

            selectedMeleeWeapon = MeleeWeaponType.Knife;
            selectedRangeWeapon = RangeWeaponType.WoodenBow;

            purchasedMeleeWeapons = new Dictionary<MeleeWeaponType, int>() {[selectedMeleeWeapon] = 1};
            purchasedRangeWeapons = new Dictionary<RangeWeaponType, int>() {[selectedRangeWeapon] = 1};

            countArtifactCells = 1;
            
            selectedArtifacts = new ArtifactsType[3] {ArtifactsType.Empty, ArtifactsType.Empty, ArtifactsType.Empty};

            purchasedArtifacts = new();
        }
        
        
        [JsonConstructor]
        public PlayerProgress(int money, int playerHealthLevel, MeleeWeaponType selectedMeleeWeapon, RangeWeaponType selectedRangeWeapon, 
            Dictionary<MeleeWeaponType, int> purchasedMeleeWeapons, Dictionary<RangeWeaponType, int> purchasedRangeWeapons,
            int countArtifactCells, ArtifactsType[] selectedArtifacts, List<ArtifactsType> purchasedArtifacts)
        {
            this.money = money;

            this.selectedMeleeWeapon = selectedMeleeWeapon;
            this.selectedRangeWeapon = selectedRangeWeapon;

            this.purchasedMeleeWeapons = new Dictionary<MeleeWeaponType, int>(purchasedMeleeWeapons);
            this.purchasedRangeWeapons = new Dictionary<RangeWeaponType, int>(purchasedRangeWeapons);

            this.countArtifactCells = countArtifactCells;
            
            this.selectedArtifacts = selectedArtifacts.ToArray();

            this.purchasedArtifacts = new List<ArtifactsType>(purchasedArtifacts);
        }
    }
}


