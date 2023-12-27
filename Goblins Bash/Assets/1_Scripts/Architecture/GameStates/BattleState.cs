using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.UIWindows;

namespace _1_Scripts.Architecture.GameStates
{
    public class BattleState : GameState 
    {
        private readonly BattleProducer _battleProducer;
        private int _currentLevel;
        
        
        public BattleState(BattleProducer battleProducer)
        {
            _battleProducer = battleProducer;
            _currentLevel = 1;
        }

        
        
        public override void Enter()
        {
            Subscribe();
            
            _battleProducer.UIService.ShowWindow(WindowType.Battle);
            _battleProducer.UIService.ShowWindow(WindowType.PlayerHud); 
            _battleProducer.WavesController.StartLevel(_battleProducer.LevelsCreator.CurrentLevel, _currentLevel);


        }
        
        public override void Exit()
        {
            Unsubscribe();
            
            _battleProducer.UIService.HideWindow(WindowType.Battle);
            _battleProducer.UIService.HideWindow(WindowType.PlayerHud); 
        }

        
        
        
        // METHODS //
        
        private void ToUpgrade()
        {
            _battleProducer.StateMachine.ChangeState(_battleProducer.PlayerUpgradeState);
            _battleProducer.LevelsCreator.CreateNextLevel();
            _currentLevel++;
        }

        private void ToLose()
        {
            _battleProducer.WavesController.StopWave();
            _battleProducer.StateMachine.ChangeState(_battleProducer.LoseGameState);
        }

        
        
        
        
        // SUB METHODS //
        
        private void Subscribe()
        {
            _battleProducer.WavesController.OnWavesOver += ToUpgrade;
            _battleProducer.Player.OnDefeated += ToLose;
        }

        private void Unsubscribe()
        {
            _battleProducer.WavesController.OnWavesOver -= ToUpgrade;
            _battleProducer.Player.OnDefeated -= ToLose;
        }
    }
}