using _1_Scripts.Items.WeaponsLogic;
using UnityEngine;

namespace _1_Scripts.Items
{
    public class ProjectilePooler : ObjectPooller<Projectile>
    {
        private readonly float _lifeTime;

        public ProjectilePooler(Projectile prefab, Transform container, int count, float lifeTime, bool isAutoExpend = true) : base(prefab, container, isAutoExpend)
        {
            _lifeTime = lifeTime;
            CreatePool(count);
        }

        public void ReturnToPool(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            projectile.selfTransform.SetParent(container);
            projectile.selfTransform.localPosition = Vector3.zero;
        }

        public override Projectile CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(this.prefab, this.container);
            createdObject.Initialize(this,_lifeTime);
            createdObject.gameObject.SetActive(isActiveByDefault);
            pool.Add(createdObject);
            return createdObject;
        }
    }
}