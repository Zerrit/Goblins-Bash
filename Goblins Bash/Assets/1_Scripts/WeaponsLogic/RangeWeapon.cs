using System;
using _1_Scripts.Enemies;
using _1_Scripts.Items;
using _1_Scripts.Items.WeaponsLogic;
using _1_Scripts.StaticData;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _1_Scripts.WeaponsLogic
{
    public class RangeWeapon : Weapon
    {
        public event Action<int> OnArrowCountChanged;
        
        public int DefaultProjectileCount { get; private set; }
        public int MaxProjectileCount { get; private set; }
        public float ProjectileCooldown { get; private set; }
        public int CurrentProjectileCount { get; private set; }
        
        
        [SerializeField]private Projectile arrowPrefab;
        
        private float _timer;
        private ObjectPooller<Projectile> _arrowPool;
        private float OffsetX => Random.Range(-.5f,.5f);
        private float OffsetY => Random.Range(1f, 1.8f);
        


        
        public void Initialize(int healthDamage, int chargeDamage, int defaultCount, int maxCount, float сooldown)
        {
            HealthDamage = healthDamage;
            ChargeDamage = chargeDamage;
            DefaultProjectileCount = defaultCount;
            MaxProjectileCount = maxCount;
            ProjectileCooldown = сooldown;
            
            _arrowPool = new ProjectilePooler(arrowPrefab, transform, MaxProjectileCount, 2f);
        }


        private void Update()
        {
            if(CurrentProjectileCount >= MaxProjectileCount) return;
            
            if (_timer > 0) _timer -= Time.deltaTime;
            else
            {
                CurrentProjectileCount++;
                OnArrowCountChanged?.Invoke(CurrentProjectileCount);
                _timer = ProjectileCooldown;
            }
        }


        public override void StartAttack(Goblin target)
        {
            if(CurrentProjectileCount <= 0) return;

            CurrentProjectileCount--;
            OnArrowCountChanged?.Invoke(CurrentProjectileCount);
            
            var arrow = _arrowPool.GetFreeElement();
            Vector3 offset = new Vector3(OffsetX, OffsetY,0f);
            var position = target.selfTransform.position;
            arrow.transform.LookAt(position + offset);
            
            arrow.transform.DOMove(position + offset, .2f).OnComplete(() =>
            {
                arrow.Attach(target);
                target.GetDamage(HealthDamage, ChargeDamage);
            });
        }
    }
}