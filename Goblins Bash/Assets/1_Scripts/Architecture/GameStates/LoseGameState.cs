using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.StateMachine;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;

namespace _1_Scripts.Architecture.GameStates
{
    public class LoseGameState : GameState
    {
        private readonly BattleProducer _battleProducer;
        
        
        public LoseGameState(BattleProducer battleProducer)
        {
            _battleProducer = battleProducer;
        }

        
        
        public override void Enter()
        {
            _battleProducer.UIService.ShowWindow(WindowType.Lose);
            _battleProducer.LoseWindowController.UpdateRunResult();
            Subscribe();
        }
        
        public override void Exit()
        {
            Unsubscribe();
            _battleProducer.UIService.HideWindow(WindowType.Lose);
        }


        private void ToHome()
        {
            Exit();
            _battleProducer.SceneLoader.LoadScene();
        }

        private void ToBattle()
        {
            // ВОЗОБНОВЛЕНИЕ БИТВЫ ПОСЛЕ ПРОСМОТРА РЕКЛАМЫ
        }
        
        // SUBSCRIBE METHODS
        private void Subscribe()
        {
            _battleProducer.LoseWindowController.OnExitButtonClick += ToHome;
        }
        private void Unsubscribe()
        {
            _battleProducer.LoseWindowController.OnExitButtonClick -= ToHome;
        }
    }            
}