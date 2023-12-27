using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.StateMachine;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;

namespace _1_Scripts.Architecture.GameStates
{
    public class PrepeareState : GameState
    {
        private readonly BattleProducer _battleProducer;
        private readonly MainInputAction _inputAction;
        
        public PrepeareState(BattleProducer battleProducer)
        {
            _battleProducer = battleProducer;

            _inputAction = new MainInputAction();
            _inputAction.Gameplay.StartGame.performed += _ => StartBattle();
        }

        public override void Enter()
        {
            _inputAction.Enable();
            _battleProducer.UIService.ShowWindow(WindowType.Prepeare);
        }

        public override void Exit()
        {
            _inputAction.Disable();
            _battleProducer.UIService.HideWindow(WindowType.Prepeare);
        }
        
        private void StartBattle() => _battleProducer.StateMachine.ChangeState(_battleProducer.BattleState);
    }
}