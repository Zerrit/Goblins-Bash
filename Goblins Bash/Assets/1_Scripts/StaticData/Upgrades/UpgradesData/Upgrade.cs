using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData.Upgrades
{
    public abstract class Upgrade : ScriptableObject
    {
        [field:SerializeField] public Sprite Icon { get; private set; }
        [field:SerializeField] public string Description { get; private set; }

        public abstract void ApplyEffect(IPlayerController player);
    }
}