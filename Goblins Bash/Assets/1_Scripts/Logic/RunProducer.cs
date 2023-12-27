using _1_Scripts.Architecture;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;

namespace _1_Scripts.Logic
{
    public class RunProducer
    {
        private readonly IUIService _uiService;
        private readonly LevelsCreator _levelsCreator;
        private readonly IPlayerMoveable _player;
        private readonly EventsBus _eventsBus;
        
        private WavesController _wavesController;

        private int _currentLevel;

        
        
        public RunProducer(LevelsCreator levelsCreator, IUIService uiService, WavesController wavesController, 
            IPlayerMoveable player, EventsBus eventsBus)
        {
            _levelsCreator = levelsCreator;
            _wavesController = wavesController;
            _uiService = uiService;
            _player = player;
            _eventsBus = eventsBus;
            
            _currentLevel = 1;
            
            _eventsBus.OnStartLevel += StartWaves;
            _wavesController.OnWavesOver += CompleteLevel;
            _eventsBus.OnClickHomeBtn += FinishRun;
        }


        private void StartWaves()
        {
            Debug.Log("Старт уровеня");
            _player.MoveToNextLevel(_levelsCreator.CurrentLevel.StayPosition, () =>
            {
                _wavesController.StartLevel(_levelsCreator.CurrentLevel, _currentLevel);
            });
        }
        
        private void CompleteLevel()
        {
            Debug.Log("Завешршение уровня");
            _levelsCreator.CreateNextLevel();
            _currentLevel++;
            _eventsBus.InvokeCompleteLevelEvent();
        }


        private void FinishRun()
        {
            _eventsBus.OnStartLevel -= StartWaves;
            _wavesController.OnWavesOver -= CompleteLevel;
            _eventsBus.OnClickHomeBtn -= FinishRun;
        }
    }
} 