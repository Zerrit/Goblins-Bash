using System;
using _1_Scripts.Enemies;
using _1_Scripts.StaticData;
using _1_Scripts.WeaponsLogic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _1_Scripts.PlayerLogic
{
    public class PlayerController : IPlayerController, IPlayerDamageable, IPlayerMoveable, ITickable, IDisposable
    {
        public event Action OnWeaponSwitched;
        public event Action<bool> OnShieldStatusSwitched;
        public event Action OnDamaged;
        public event Action OnDefeated;
        public event Action<Transform, Action> OnMoveToNewPosition; 
        
        public event Action<Camera> OnHit;
        
                
        public PlayerHealth PlayerHealth { get; }
        public PlayerStamina PlayerStamina { get; }
        public WeaponController WeaponController { get; private set; }
        
        private Camera _camera;
        
        private readonly MainInputAction _inputSystem;
        private readonly GeneralStaticData _data;
        private readonly WeaponsFactory _weaponsFactory;


        
        public PlayerController(IStaticDataService staticDataService, WeaponsFactory weaponsFactory)
        {
            _data = staticDataService.GeneralStaticData;
            _weaponsFactory = weaponsFactory;
            
            PlayerHealth = new PlayerHealth(_data.PlayerHealth);
            PlayerStamina = new PlayerStamina(_data.PlayerStamina, _data.StaminaReduceRate, _data.StaminaIncreaseRate);

            _inputSystem = new MainInputAction();

            _inputSystem.Gameplay.Attack.performed += _ => Attack();
            _inputSystem.Gameplay.SwitchWeapon.performed += _ => SwitchWeapon();
            _inputSystem.Gameplay.Shield.performed += _ => SwitchShieldStatus(true);
            _inputSystem.Gameplay.Shield.canceled += _ => SwitchShieldStatus(false);
            _inputSystem.Enable();
        }

        public void InitializePlayer(Camera camera, Transform weaponHolder)
        {
            _camera = camera;
            WeaponController = new WeaponController(_weaponsFactory, weaponHolder);
        }
        
        public void Tick()
        {
            PlayerStamina.ProcessStamina();
        }
        
        public void MoveToNextLevel(Transform target, Action onMoved)
        {
            OnMoveToNewPosition?.Invoke(target,onMoved);
        }
        
        public void SwitchWeapon()
        {
            WeaponController.ChangeWeapon();
            OnWeaponSwitched?.Invoke();
        }

        public void SwitchShieldStatus(bool isActive)
        {
            PlayerStamina.isShieldActive = isActive;
            OnShieldStatusSwitched?.Invoke(isActive);
        }
        
        public void GetDamage(int damage)
        {
            if(PlayerStamina.isShieldActive) return;
            
            if(PlayerHealth.ReduceHealth(damage)) DefeatSelf();
            OnDamaged?.Invoke();
            _camera.DOShakePosition(_data.PlayerDamageShakeDuration, _data.PlayerDamageShakeStrength);
        }



        private void Attack()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (!Physics.Raycast(ray, out RaycastHit hit)) return;
            
            if(hit.collider.TryGetComponent(out Goblin goblin))
                 WeaponController.UseWeapon(goblin);
        }

        
        private void DefeatSelf()
        {
            Debug.Log("Поражение"); 
            OnDefeated?.Invoke();
        }

        public void Dispose()
        {
            _inputSystem.Disable();
        }
    }
}