using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.UIWindows;

namespace _1_Scripts.Architecture.GameStates
{
    public class PlayerUpgradeState : GameState
    {
        private readonly BattleProducer _battleProducer;
        
        
        public PlayerUpgradeState(BattleProducer battleProducer)
        {
            _battleProducer = battleProducer;
        }


        
        public override void Enter()
        {
            Subscribe();
            
            _battleProducer.UIService.ShowWindow(WindowType.Upgrade);
            _battleProducer.UpgradeSystem.UpdateStack();
        }
        
        public override void Exit()
        {
            Unsubscribe();
            
            _battleProducer.UIService.HideWindow(WindowType.Upgrade);
        }

        
        
        private void ToNextLevel()
        {
            _battleProducer.StateMachine.ChangeState(_battleProducer.LevelTransitionState);
        }

        
        // SUBSCRIBE METHODS
        private void Subscribe()
        {
            _battleProducer.UpgradeSystem.OnUpgradeFinished += ToNextLevel;
        }
        private void Unsubscribe()
        {
            _battleProducer.UpgradeSystem.OnUpgradeFinished -= ToNextLevel;
        }
    }
}