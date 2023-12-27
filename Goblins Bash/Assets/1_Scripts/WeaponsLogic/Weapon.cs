using _1_Scripts.Enemies;
using UnityEngine;

namespace _1_Scripts.WeaponsLogic
{
    public abstract class Weapon : MonoBehaviour
    {
        public int HealthDamage { get; set; }
        public int ChargeDamage { get; set; }
        public abstract void StartAttack(Goblin target);
    }
}