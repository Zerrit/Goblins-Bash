using _1_Scripts.Items.ItemVisitors;
using _1_Scripts.Items.WeaponsLogic;
using _1_Scripts.WeaponsLogic;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    public abstract class WeaponStaticData : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
        [field:SerializeField] public int Price { get; private set; }
        
        [field:SerializeField] public int HealthDamage { get; private set; }
        [field:SerializeField] public int ChargeDamage { get; private set; }
        
        
        [field:SerializeField] public Weapon Prefab { get; protected set; }
        
        public virtual void Accept(IItemVisitor visitor) => visitor.Visit(this);
    }
} 