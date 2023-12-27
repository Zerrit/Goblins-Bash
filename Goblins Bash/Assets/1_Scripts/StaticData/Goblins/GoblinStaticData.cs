using _1_Scripts.Enemies;
using _1_Scripts.Enemies.Goblins;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    [CreateAssetMenu(fileName = "New Goblin", menuName = "Create Goblin/New Goblin")]
    public class GoblinStaticData : ScriptableObject
    {
        public GoblinType goblinType;
        public EnemyPlacementType placementType;
        public int damage;
        public int health;
        public int maxCharge;
        public int defaultCharge;
        public int reward;
        
        public Goblin prefub;
    }
}