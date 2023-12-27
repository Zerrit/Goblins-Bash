using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.StateMachine;

namespace _1_Scripts.Architecture.GameStates
{
    public class LoadDataGameState : GameState
    {
        private readonly GameStateMachine _stateMachine;
        
        public LoadDataGameState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}