using _1_Scripts.Architecture.StateMachine;

namespace _1_Scripts.Architecture.GameStates
{
    public class LevelTransitionState : GameState
    {
        private readonly BattleProducer _battleProducer;
        
        
        public LevelTransitionState(BattleProducer battleProducer)
        {
            _battleProducer = battleProducer;
        }

        public override void Enter()
        {
            _battleProducer.Player.MoveToNextLevel(_battleProducer.LevelsCreator.CurrentLevel.StayPosition, ToBattle);
        }
        
        public override void Exit()
        {

        }

        private void ToBattle()
        {
            _battleProducer.StateMachine.ChangeState(_battleProducer.BattleState);
        }
    }
}