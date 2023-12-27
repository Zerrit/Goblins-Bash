using System.Collections.Generic;
using UnityEngine;

namespace _1_Scripts.Enemies
{
    public class GoblinPooler
    {
        private List<Goblin> _pool;
        private int _golbinId;
        private readonly EnemiesFactory _factory;
        private readonly Transform _container;
        

        public GoblinPooler(EnemiesFactory factory, Transform container, int goblinId, int count)
        {
            _factory = factory;
            _container = container;
            _golbinId = goblinId;
            CreatePool(count);
        }
        
        
        public void CreatePool(int count)
        {
            _pool = new List<Goblin>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        public Goblin CreateObject()
        {
            Goblin goblin = _factory.GetGoblin(_golbinId, _container);
            goblin.gameObject.SetActive(false);
            _pool.Add(goblin);
            return goblin;
        }

        public bool HasFreeElement(out Goblin freeGoblin)
        {
            foreach (Goblin goblin in _pool)
            {
                if (!goblin.gameObject.activeInHierarchy)
                {
                    freeGoblin = goblin;
                    return true;
                }
            }
            freeGoblin = null;
            return false;
        }

        public Goblin GetFreeElement()
        {
            if (HasFreeElement(out Goblin goblin))
            {
                goblin.gameObject.SetActive(true);
                return goblin;
            }

            return CreateObject();
        }
    }
    
}