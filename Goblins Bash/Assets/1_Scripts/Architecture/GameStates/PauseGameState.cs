using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.StateMachine;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _1_Scripts.Architecture.GameStates
{
    public class PauseGameState : GameState
    {
        private GameStateMachine _stateMachine;
        private IUIService _uiService;
        private EventsBus _eventsBus;
        private MainInputAction _inputAction;
        
        public PauseGameState(GameStateMachine stateMachine, IUIService uiService, EventsBus eventsBus)
        {
            _stateMachine = stateMachine;
            _uiService = uiService;
            _eventsBus = eventsBus;

            _inputAction = new MainInputAction();
            //_inputAction.Gameplay.StartGame.performed += _ => StartBattle();
        }

        public void Enter()
        {
            _inputAction.Enable();
            //_uiService.ShowModule(ModuleType.Pause);
        }

        public void Update()
        {
        }

        public void Exit()
        {
           //_uiService.HideModule(ModuleType.Pause);
            _inputAction.Disable();
        }


        //private void StartBattle() => //_stateMachine.ChangeState<BattleState>();
    }
}