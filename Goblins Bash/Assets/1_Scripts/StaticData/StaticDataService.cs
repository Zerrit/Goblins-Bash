using System.Collections.Generic;
using System.Linq;
using _1_Scripts.Architecture;
using _1_Scripts.Enemies;
using _1_Scripts.Items;
using _1_Scripts.Items.Artifacts;
using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData.UIModules;
using _1_Scripts.StaticData.Upgrades;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private GeneralStaticData _generalStaticData;
        private LoadScreen _loadScreen;
        private GameObject _rootUI;
        private Dictionary<WindowType, UIWindow> _uiModules;
        private Dictionary<GoblinType, GoblinStaticData> _goblins;
        private Dictionary<MeleeWeaponType, MeleeWeaponStaticData> _meleeWeapons;
        private Dictionary<RangeWeaponType, RangeWeaponStaticData> _rangeWeapons;
        private Dictionary<ArtifactsType, Artifact> _artifacts;
        private List<Upgrade> _upgrades;
        private List<Level> _levels;

        
        public StaticDataService()
        {
            LoadGeneralStaticData();
            LoadLoadindScreen();
            LoadUIModules();
            LoadGoblinsStaticData();
            LoadWeaponStaticData();
            LoadArtifactStaticData();
            LoadUpgrades();
            LoadLevels();
        }

        public GeneralStaticData GeneralStaticData => _generalStaticData;
        public LoadScreen LoadScreen => _loadScreen;
        public GameObject RootUI => _rootUI;
        public IReadOnlyList<GoblinStaticData> Goblins => _goblins.Values.ToList().AsReadOnly();
        public IEnumerable<MeleeWeaponStaticData> MeleeWeapons => _meleeWeapons.Values;
        public IEnumerable<RangeWeaponStaticData> RangeWeapons => _rangeWeapons.Values;
        public IEnumerable<Artifact> Artifacts => _artifacts.Values;
        public IReadOnlyList<Upgrade> Upgrades => _upgrades;
        public IEnumerable<Level> Levels => _levels;


        public UIWindow GetDataFor(WindowType windowType) =>
            _uiModules.TryGetValue(windowType, out UIWindow data) ? data : null;
        
        public GoblinStaticData GetDataFor(GoblinType typeId) =>
            _goblins.TryGetValue(typeId, out GoblinStaticData data) ? data : null;
        
        public MeleeWeaponStaticData GetDataFor(MeleeWeaponType typeId) =>
            _meleeWeapons.TryGetValue(typeId, out MeleeWeaponStaticData data) ? data : null;
        
        public RangeWeaponStaticData GetDataFor(RangeWeaponType typeId) =>
            _rangeWeapons.TryGetValue(typeId, out RangeWeaponStaticData data) ? data : null;

        public Artifact GetDataFor(ArtifactsType typeId) => 
            _artifacts.TryGetValue(typeId, out Artifact data) ? data: null;
        
        
        
        
        
        // ЗАГРУЗКА СТАТИЧЕСКИХ ДАННЫХ В СЕРВИС
        private void LoadGeneralStaticData()
        {
            _generalStaticData = Resources.Load<GeneralStaticData>("StaticData/GeneralParameters");
        }
        private void LoadLoadindScreen()
        {
            _loadScreen = Resources.Load<LoadScreen>("StaticData/LoadScreen");
        }
        private void LoadUIModules()
        {
            AllUIModulesData allWindows = Resources.Load<AllUIModulesData>("StaticData/UI/AllUIModules");
            
            _rootUI = allWindows.RootUI;
            _uiModules = allWindows.UIModules.ToDictionary(x => x.Type, x => x);
        }
        private void LoadGoblinsStaticData()
        {
            _goblins = Resources.Load<AllGoblinsData>("StaticData/Goblins/AllGoblins")
                .Goblins.ToDictionary(x => x.goblinType, x => x);
        }
        private void LoadWeaponStaticData()
        {
            AllWeaponsData allWeapon = Resources.Load<AllWeaponsData>("StaticData/Weapons/AllWeapons");
            
            _meleeWeapons = allWeapon.MeleeWeaponItems
                .ToDictionary(x => x.TypeId, x => x);
            _rangeWeapons = allWeapon.RangeWeaponItems.
                ToDictionary(x => x.TypeId, x => x);
        }
        private void LoadArtifactStaticData()
        {
            _artifacts = Resources.Load<AllArtifactsData>("StaticData/Artifacts/AllArtifacts")
                .Artifacts.ToDictionary(x => x.ArtifactId, x => x);
        }
        private void LoadUpgrades()
        {
            _upgrades = Resources.Load<AllUpgradesData>("StaticData/Upgrades/AllUpgrades")
                .Upgrades.ToList();
        }
        private void LoadLevels()
        {
            _levels = Resources.Load<AllLevelsData>("StaticData/Levels/AllLevels")
                .Levels.ToList();
        }
    }
}
 