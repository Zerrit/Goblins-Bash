using System;
using System.Collections;
using System.Collections.Generic;
using _1_Scripts.Enemies;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _1_Scripts.Logic
{
    public class WavesController : IWavesController
    {
        public event Action<int> OnStartLevel;
        public event Action<int> OnWaveStarted; 
        public event Action OnWavesOver;
        
        public Level CurrentLevel { get; private set; }
        
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IUIService _uiService;
        private readonly EnemySpawner _enemySpawner;
        
        private List<Goblin> _waveQueue = new();
        private List<Goblin> _goblinsOnField = new();

        private Coroutine _battleCoroutine;

        private int _levelId;
        private int _currentWave;
        private int _maxActiveEnemies;
        private int _activeEnemies;
        private int _remainsEnemies;
        
        private const int WaveCount = 3;
        
        
        public WavesController(ICoroutineRunner coroutineRunner, IUIService uiService, EnemySpawner enemySpawner)
        {
            _coroutineRunner = coroutineRunner;
            _uiService = uiService;
            _enemySpawner = enemySpawner;
        }
        
        
        public void StartLevel(Level newLevel, int levelId)
        {
            _currentWave = 1;
            _maxActiveEnemies = 2;
            _levelId = levelId;
            _enemySpawner.UpdatePool(_levelId);
            CurrentLevel = newLevel;
            ContainWave();
            StartWave();
        }
        
        public void StopWave() => _coroutineRunner.StopCoroutine(_battleCoroutine);

        private void StartWave() => _battleCoroutine = _coroutineRunner.StartCoroutine(WaveGeneration());
        

        
        // НАПОЛНЕНИЕ ОЧЕРЕДИ ДЛЯ ВОЛНЫ
        private void ContainWave()
        {
            _remainsEnemies = _enemySpawner.GetWave(ref _waveQueue);
            ConfigureWave();
        }

        private void ConfigureWave()
        {
            Debug.LogWarning("Посписки на гоблинов оформлены");
            foreach (Goblin enemy in _waveQueue)
            {
                enemy.UpdateParameters(_levelId, CurrentLevel);
                enemy.gameObject.SetActive(false);
                enemy.selfTransform.SetParent(CurrentLevel.SafePlace.PlaceTransform, false);

                enemy.OnDisappeared += ReturnToQueue;
                enemy.OnDefeated += ReturnToStorage;
            }
        }
        

        // СТАРТ РАБОТЫ ОЧЕРЕДИ ВРАГОВ
        private IEnumerator WaveGeneration()
        {
            OnWaveStarted?.Invoke(_currentWave);
            yield return new WaitForSeconds(2f);  //WAVE ANNOUNCE

            while (_remainsEnemies > 0)
            {
                Debug.LogWarning(_remainsEnemies);
                if (_goblinsOnField.Count < _maxActiveEnemies)
                    EnterEnemy();
                yield return new WaitForSeconds(.3f);
            }
            Debug.LogWarning("Волна завершилась");
            FinishWave();
        }
        
        
        private void EnterEnemy()
        {
            int i = _waveQueue.Count;
            if (i > 0)
            {
                int index = Random.Range(0, i);
                var enemy = _waveQueue[index];
                _waveQueue.RemoveAt(index);
                
                AddActiveAnemies(enemy);

                enemy.gameObject.SetActive(true);
                enemy.Appear();
            }
        }
        
        
        private void FinishWave()
        {
            ResetWaveParameters();
            _currentWave++;
            
            if (_currentWave > WaveCount)
            {
                OnWavesOver?.Invoke();
                Debug.Log("Уровень закончилась");
            }
            else
            {
                ContainWave();
                Debug.Log("Волна закончилась"+ _currentWave);
                StartWave();
            }
        }

        private void AddActiveAnemies(Goblin enemy)
        {
            _goblinsOnField.Add(enemy);
            _activeEnemies++;
        }
        
        private void RemoveActiveAnemies(Goblin enemy)
        {
            _goblinsOnField.Remove(enemy);
            _activeEnemies--;
        }
        
        
        private void ResetWaveParameters()
        {
            _activeEnemies = 0;
            _remainsEnemies = 0;
        }
        
        
        
        // ОБРАБОТЧИКИ СОБЫТИЙ КОНТРОЛИРУЕМЫХ ЮНИТОВ
        private void ReturnToQueue(Goblin goblin)
        {
            RemoveActiveAnemies(goblin);
            _waveQueue.Add(goblin);
        }
        
        
        private void ReturnToStorage(Goblin goblin)
        {
            RemoveActiveAnemies(goblin);
            _enemySpawner.ReturnToPool(goblin.selfTransform);
            _remainsEnemies--;
        }
    }
}
