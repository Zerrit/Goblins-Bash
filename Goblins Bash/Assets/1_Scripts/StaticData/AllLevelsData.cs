using System.Collections.Generic;
using _1_Scripts.Logic;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    [CreateAssetMenu(fileName = "All Levels", menuName = "Create All Levels")]
    public class AllLevelsData : ScriptableObject
    {
        [SerializeField] private List<Level> levels;

        public IEnumerable<Level> Levels => levels;
    }
}