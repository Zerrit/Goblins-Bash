using System.Collections.Generic;
using _1_Scripts.Items;
using UnityEngine;

namespace _1_Scripts.StaticData
{    
    [CreateAssetMenu(fileName = "All Goblins", menuName = "Create Goblin/All Goblins")]
    public class AllGoblinsData : ScriptableObject
    {
        [SerializeField] private List<GoblinStaticData> goblins;

        public IEnumerable<GoblinStaticData> Goblins => goblins;
    }
}