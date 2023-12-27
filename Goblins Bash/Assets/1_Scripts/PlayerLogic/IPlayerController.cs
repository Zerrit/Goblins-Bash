using System;
using _1_Scripts.Enemies;
using UnityEngine;

namespace _1_Scripts.PlayerLogic
{
    public interface IPlayerController
    {
        public event Action OnWeaponSwitched;
        public event Action<bool> OnShieldStatusSwitched;
        public event Action OnDamaged;
        public event Action OnDefeated;
        public event Action<Transform, Action> OnMoveToNewPosition;


        public PlayerHealth PlayerHealth { get;}
        public PlayerStamina PlayerStamina { get;}
        public WeaponController WeaponController { get;}

        public void InitializePlayer(Camera camera, Transform weaponHolder);
        public void SwitchWeapon();
        public void SwitchShieldStatus(bool isActive);
        public void MoveToNextLevel(Transform target, Action onMoved);
    }
}