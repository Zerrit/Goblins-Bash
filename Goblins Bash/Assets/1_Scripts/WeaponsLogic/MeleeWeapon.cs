using _1_Scripts.Enemies;
using _1_Scripts.Items;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.WeaponsLogic
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private Animator animator;
        
        public float AttackSpeed { get; set; }
        
        private bool _isAttackBuffer;
        private float _attackDuration;
        private float _timeBeforeAttack;
        
        private Goblin _lastGoblin;
        private Goblin _currentGoblin;
        
        private static readonly int NextAttack = Animator.StringToHash("NextAttack");
        private static readonly int SpeedMultiplier = Animator.StringToHash("SpeedMultiplier");


        public void Initialize(int healthDamage, int chargeDamage, float attackSpeed)
        {
            HealthDamage = healthDamage;
            ChargeDamage = chargeDamage;
            AttackSpeed = attackSpeed;
            animator.speed = AttackSpeed;
            //animator.SetFloat(SpeedMultiplier, AttackSpeed);
            _attackDuration = 1f / AttackSpeed * .6f;
        }

        private void Update()
        {
            if (_timeBeforeAttack > 0)
                _timeBeforeAttack -= Time.deltaTime;
            else
            {
                if (_isAttackBuffer)
                {
                    StartAttack(_currentGoblin);
                    _isAttackBuffer = false;
                }
                else gameObject.SetActive(false); 
                
            }
        }

        public override void StartAttack(Goblin target)
        {
            if (target != _currentGoblin)
            {
                _lastGoblin = _currentGoblin;
                _currentGoblin = target;
            }
            
            if(_timeBeforeAttack > 0)
            {
                _isAttackBuffer = true;
                return;
            }
            
            _currentGoblin = target;
            transform.position = target.selfTransform.position + new Vector3(0f, 1.2f,0f);
            _timeBeforeAttack = _attackDuration;
            gameObject.SetActive(true); 
            animator.SetTrigger(NextAttack);
        }

        public void Damage()
        {
            if(_currentGoblin != null && _currentGoblin.IsInteractive)
                _currentGoblin.GetDamage(HealthDamage, ChargeDamage);
        }
        
        
    }
}