using System;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.UIModules
{
    [CreateAssetMenu(fileName = "ItemsViewFactory", menuName = "Shop/Items View Factory")]
    public class ItemViewFactory : ScriptableObject
    {
        [SerializeField] private WeaponItemView meleeWeaponItemViewPrefub;
        [SerializeField] private WeaponItemView rangeWeaponItemViewPrefub;

        public WeaponItemView Get(WeaponStaticData item, Transform parent)
        {
            WeaponItemView instance;

            switch (item)
            {
                case MeleeWeaponStaticData:
                {
                    instance = Instantiate(meleeWeaponItemViewPrefub, parent);
                    break;
                }
                case RangeWeaponStaticData:
                {
                    instance = Instantiate(rangeWeaponItemViewPrefub, parent);
                    break;
                }
                default:
                {
                    throw new ArgumentException(nameof(item));
                }
            }
            
            instance.Initialize(item);
            return instance;
        }
    }
}