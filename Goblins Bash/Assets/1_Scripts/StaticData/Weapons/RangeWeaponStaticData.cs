using _1_Scripts.Items.ItemVisitors;
using _1_Scripts.Items.WeaponsLogic;
using _1_Scripts.WeaponsLogic;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    [CreateAssetMenu(fileName = "RangeWeapon", menuName = "Create Weapon/Range Weapon")]
    public class RangeWeaponStaticData : WeaponStaticData
    {
        [field:SerializeField] public int DefaultProjectileCount { get; private set; }
        [field:SerializeField] public int MaxProjectileCount { get; private set; }
        [field:SerializeField] public float ProjectileCooldown { get; private set; }

        
        [field:SerializeField] public RangeWeaponType TypeId { get; private set; }
        
        public override void Accept(IItemVisitor visitor) => visitor.Visit(this);
    }
}