using System.Collections.Generic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    [CreateAssetMenu(fileName = "AllUpgrade", menuName = "Create Upgrade/All Upgrades")]
    public class AllUpgradesData : ScriptableObject
    {
        [field:SerializeField] public List<Upgrade> Upgrades { get; private set; }
    }
}