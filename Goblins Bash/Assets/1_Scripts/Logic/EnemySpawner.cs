using System.Collections.Generic;
using _1_Scripts.Enemies;
using UnityEngine;

namespace _1_Scripts.Logic
{
    public class EnemySpawner
    {
        private readonly List<GoblinPooler> _goblinsPools;
        private readonly EnemiesFactory _factory;
        private readonly Transform _storagePoint;

        // PARAMETERS
        public int currentDiversity;
        public int waveSize;


        public EnemySpawner(EnemiesFactory factory)
        {
            _factory = factory;
            _goblinsPools = new List<GoblinPooler>();
            _storagePoint = new GameObject("GoblinStorage").transform;
        }


        public void UpdatePool(int level)
        {
            UpdatePoolList(level);
            UpdateWaveSize(level);
        }

        public int GetWave(ref List<Goblin> wave)
        {
            int divIndex = 0;
            wave.Clear();
            for (int i = 0; i < waveSize; i++)
            {
                if (divIndex == currentDiversity) divIndex = 0;

                wave.Add(_goblinsPools[divIndex].GetFreeElement());
                divIndex++;
            }
            return waveSize;
        }

        public void ReturnToPool(Transform enemy) => enemy.SetParent(_storagePoint, false);
        private void UpdateWaveSize(int lvl) => waveSize = 6 + (lvl/2);
        private void UpdateWaveDiversity(int lvl) => currentDiversity = 2 + lvl / 3;

        
        private void UpdatePoolList(int lvl)
        {
            UpdateWaveDiversity(lvl);
            int poolCount = _goblinsPools.Count;

            for (int i = 0; i < currentDiversity; i++)
            {
                if (poolCount <= i)
                {
                    _goblinsPools.Add(new GoblinPooler(_factory, _storagePoint, i, 5));
                }
            }
        }

        private void OnDestroy()
        {
            _goblinsPools.Clear();
        }
    }
}
