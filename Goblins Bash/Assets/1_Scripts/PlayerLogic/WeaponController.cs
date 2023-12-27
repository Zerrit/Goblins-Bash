using _1_Scripts.Enemies;
using _1_Scripts.WeaponsLogic;
using UnityEngine;

namespace _1_Scripts.PlayerLogic
{
    public class WeaponController
    {
        public MeleeWeapon MeleeWeapon { get; }
        public RangeWeapon RangeWeapon { get; }
        private Weapon _choosenWeapon;
        
        public WeaponController(WeaponsFactory weaponsFactory, Transform parent)
        {
            MeleeWeapon = weaponsFactory.GetMeleeWeapon();
            MeleeWeapon.transform.SetParent(parent, false);
            
            RangeWeapon = weaponsFactory.GetRangeWeapon();
            RangeWeapon.transform.SetParent(parent, false);
            
            _choosenWeapon = MeleeWeapon;
        }

        

        public void UseWeapon(Goblin target)
        {
            if(target.IsInteractive)
                _choosenWeapon.StartAttack(target);
        }
        
        public void ChangeWeapon()
        {
            _choosenWeapon = (_choosenWeapon == MeleeWeapon) ? RangeWeapon : MeleeWeapon;
        }
    }
}