using System.Collections.Generic;
using _1_Scripts.Items;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    [CreateAssetMenu(fileName = "All Weapons", menuName = "Create Weapon/All Weapon")]
    public class AllWeaponsData : ScriptableObject
    {
        [SerializeField] private List<MeleeWeaponStaticData> meleeWeapon;
        [SerializeField] private List<RangeWeaponStaticData> rangeWeapon;

        public IEnumerable<MeleeWeaponStaticData> MeleeWeaponItems => meleeWeapon;
        public IEnumerable<RangeWeaponStaticData> RangeWeaponItems => rangeWeapon;
    }
}