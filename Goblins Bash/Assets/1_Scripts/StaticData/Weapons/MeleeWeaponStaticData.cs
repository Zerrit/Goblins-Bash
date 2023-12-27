using _1_Scripts.Items;
using _1_Scripts.Items.ItemVisitors;
using _1_Scripts.Items.WeaponsLogic;
using _1_Scripts.WeaponsLogic;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    [CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Create Weapon/Melee Weapon")]
    public class MeleeWeaponStaticData : WeaponStaticData
    {
        [field:SerializeField] public float AttaskSpeed { get; private set; }
        
        [field:SerializeField] public MeleeWeaponType TypeId { get; private set; }
        
        public override void Accept(IItemVisitor visitor) => visitor.Visit(this);
    }
}