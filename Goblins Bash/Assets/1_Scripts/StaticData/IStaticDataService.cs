using System.Collections.Generic;
using _1_Scripts.Architecture;
using _1_Scripts.Enemies;
using _1_Scripts.Items;
using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData.Upgrades;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    public interface IStaticDataService
    {
        public GeneralStaticData GeneralStaticData { get; }
        public LoadScreen LoadScreen { get; }
        public GameObject RootUI { get; }
        public IReadOnlyList<GoblinStaticData> Goblins { get; }
        public IEnumerable<MeleeWeaponStaticData> MeleeWeapons { get; }
        public IEnumerable<RangeWeaponStaticData> RangeWeapons { get; }
        public IEnumerable<Artifact> Artifacts { get; }
        public IReadOnlyList<Upgrade> Upgrades { get; }
        public IEnumerable<Level> Levels { get; }

        public UIWindow GetDataFor(WindowType windowType);
        GoblinStaticData GetDataFor(GoblinType typeId);
        MeleeWeaponStaticData GetDataFor(MeleeWeaponType typeId);
        RangeWeaponStaticData GetDataFor(RangeWeaponType typeId);
        Artifact GetDataFor(ArtifactsType typeId);
    }
}