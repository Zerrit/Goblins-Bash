using System;
using _1_Scripts.Enemies.Goblins;
using _1_Scripts.GameProgress;
using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using _1_Scripts.WeaponsLogic;
using UnityEngine;

namespace _1_Scripts.Enemies
{
    public class Goblin : MonoBehaviour
    {
        public event Action<Goblin> OnDefeated;
        public event Action<Goblin> OnDisappeared;
        
        public bool IsInteractive { get; private set; }
        
        [SerializeField] protected HealthBar healthBarBar;
        [SerializeField] protected ChargeBar chargeBar;
        [SerializeField] protected BoxCollider boxCollider;
        [SerializeField] protected Animator animator;
        
        [SerializeField] public Transform selfTransform;
        [SerializeField] public Transform bodyTransform;
        
        [SerializeField] protected ParticleSystem impactFX;
        [SerializeField] protected ParticleSystem blockFX;
        [SerializeField] protected ParticleSystem resurectionFX;
        
        protected EnemyPlacementType placementType;
        protected IPlayerDamageable player;
        protected IRewardable rewardService;
        protected Level level;
        protected Place takenPlace;
        
        
        protected int damage;

        // BASE PARAMETERS
        private int _damage;
        private int _health;
        private int _maxCharge;
        private int _defaultCharge;
        private int _reward;
        
        
        protected readonly string KnockoutTrigger = "Knockout";
        protected readonly string AttackTrigger = "Attack";
        protected readonly string DeathTrigger = "Death";

        

        public virtual void Initialize(IPlayerDamageable playerDamageable, IRewardable playerReward, EnemyPlacementType enemyPlacementType,
            int defaultDamage, int defaultHealth, int maxCharge, int defaultCharge, int reward)
        {
            animator.writeDefaultValuesOnDisable = true;
            player = playerDamageable;
            rewardService = playerReward;
            
            placementType = enemyPlacementType;
            _damage = defaultDamage;
            _health = defaultHealth;
            _maxCharge = maxCharge;
            _defaultCharge = defaultCharge;
            _reward = reward;

        }

        public void UpdateParameters(int levelId, Level currentLevel)
        {
            level = currentLevel;
            healthBarBar.Initialize(StaticFormulas.GetEnemyHealth(levelId, _health));
            chargeBar.Initialize(_maxCharge, _defaultCharge, FullChargeAction);
            damage = StaticFormulas.GetEnemyDamage(levelId, _damage);
        }
        
        
        
        // ЗАПУСК ПЕРСОНАЖА НА СЦЕНУ ДЛЯ ВЗАИМОДЕЙСТВИЯ
        public virtual void Appear()
        {
            TakePlace();
            takenPlace.Show(() =>
            {
                SwitchInteractable(true);
                chargeBar.StartCharging();
            });
        }
        
        // УХОД ПЕРСОНАЖА СО СЦЕНЫ
        public virtual void Disappear()
        {
            SwitchInteractable(false);
            chargeBar.StopCharging();
            
            takenPlace.Hide(TakeSafePlace);
        }

        protected virtual void Die()
        {
            SwitchInteractable(false);
            chargeBar.StopCharging();
            rewardService.AddMoney(_reward);
            
            takenPlace.Hide(LeaveBattle);
        }
        
        
        
        // НЕПОСРЕДСТВЕННАЯ АТАКА
        public virtual void StartAttack()
        {
            SwitchInteractable(false);
            animator.SetTrigger(AttackTrigger);
        }

        public virtual void Attack()
        {
            player.GetDamage(damage);
            chargeBar.ReduceChargeToDefault();
        }


        protected virtual void Knockout()
        {
            //knockoutFX.Play();
        }

        
        // СИСТЕМА ПОЛУЧЕНИЯ УРОНА
        public virtual void GetDamage(int healthDamage, int chargeDamage)
        {
            if(!IsInteractive) return;
            
            if (CheckProvocationStatus())
            {
                blockFX.Play();
                return;
            }
            
            impactFX.Play();
            KnockBack(chargeDamage);           
            if(healthBarBar.ReduceHealth(healthDamage)) Die();
        }

        protected void KnockBack(int chargeDamage)
        {
            animator.SetTrigger(KnockoutTrigger);
            chargeBar.ReduceCharge(chargeDamage);
        }
        
        
        protected virtual void FullChargeAction() => StartAttack();
        protected virtual void ZeroChargeAction() => Knockout();
        protected virtual void AfterAttackAction() => Disappear();
        
        
        private bool CheckProvocationStatus() =>  level.Statuses.TryGetStatus(StatusType.ProvocationStatus);


        // ПЕРЕКЛЮЧАТЕЛИ КОЛАЙДЕРА
        public void SwitchInteractable(bool isInteractable)
        {
            IsInteractive = isInteractable;
            boxCollider.enabled = isInteractable;
        }

        
        // ВЗАИМОДЕЙСТВИЕ С ПОЗИЦИЯМИ НА УРОВНЕ
        protected virtual void TakePlace()
        {
            if(level.GetPlace(ref takenPlace, placementType))
                transform.SetParent(takenPlace.PlaceTransform, false);
        }
        
        protected virtual void TakeSafePlace()
        {
            level.ReturnPlace(takenPlace);
            
            takenPlace = level.SafePlace;
            transform.SetParent(takenPlace.PlaceTransform, false);

            OnDisappeared?.Invoke(this);
            
            gameObject.SetActive(false);
        }
        
        protected virtual void LeaveBattle()
        {
            level.ReturnPlace(takenPlace);
            OnDefeated?.Invoke(this);
            OnDefeated = null;
            OnDisappeared = null;
            gameObject.SetActive(false);
        }



        // ПРОВЕРКА УЯЗВИМОСТИ К ВЫБРАННОМУ ОРУЖИЮ
        public bool CheckSusceptibility(Weapon weapon)
        {
            return weapon switch
            {
                MeleeWeapon => (takenPlace.PlaceType == PlaceType.Melee),
                RangeWeapon => (takenPlace.PlaceType == PlaceType.Range),
                _ => false
            };
        }
        

        /// /////////////////////////////////////////
        // АВТОЗАПОЛНЕНИЕ ИНСПЕКТОРА
        private void OnValidate()
        {
            if(healthBarBar == null) 
                healthBarBar = GetComponentInChildren<HealthBar>();
            if (chargeBar == null)
                chargeBar = GetComponentInChildren<ChargeBar>();
            if (boxCollider == null)
                boxCollider = GetComponent<BoxCollider>();
            if (animator == null)
                animator = GetComponent<Animator>();
            if (selfTransform == null)
                selfTransform = transform;
        }
        
    }
}