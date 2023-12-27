using System.Collections.Generic;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Logic
{
    public class LevelsCreator : ILevelsCreator
    {
        public Level CurrentLevel { get; private set; }
        
        private readonly Queue<Level> _levels;
        private int _createdLevels;


        public LevelsCreator(IStaticDataService staticDataService)
        {
            _levels = new Queue<Level>(staticDataService.Levels);
            CreateStartLevel();
            Debug.LogWarning("Создан уровень");
        }


        public void CreateStartLevel()
        {
            CurrentLevel = Object.Instantiate(_levels.Dequeue());
            _levels.Enqueue(CurrentLevel);
            _createdLevels = 1;
        }

        
        public void CreateNextLevel()
        {
            CurrentLevel = Object.Instantiate(_levels.Dequeue(), CurrentLevel.SnapTransform.position, Quaternion.identity);
            _levels.Enqueue(CurrentLevel);
            
            if(_createdLevels > 2) DestroyLastLevel();
        }

        private void DestroyLastLevel()
        {
            Object.Destroy(_levels.Dequeue());
            _createdLevels--;
        }
    }
}
