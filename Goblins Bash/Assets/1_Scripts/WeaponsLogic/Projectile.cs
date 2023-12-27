using _1_Scripts.Enemies;
using UnityEngine;

namespace _1_Scripts.Items.WeaponsLogic
{
    public class Projectile: MonoBehaviour
    {
        public Transform selfTransform;
        private ProjectilePooler _pool;
        private Goblin _target;
        private bool _isAttached;
        private float _attachTime;
        private float _lifeTime;

        public void Initialize(ProjectilePooler pool, float lifeTime)
        {
            _pool = pool;
            _lifeTime = lifeTime;
            selfTransform = transform;
        }

        private void Update()
        {
            if (_isAttached)
            {
                if (Time.time >= _attachTime + _lifeTime || !_target.IsInteractive)
                {
                    _pool.ReturnToPool(this);
                    _isAttached = false;
                }
            }
        }

        public void Attach(Goblin target)
        {
            _target = target;
            _attachTime = Time.time;
            _isAttached = true;
            selfTransform.SetParent(target.bodyTransform, true);
        }
    }
}