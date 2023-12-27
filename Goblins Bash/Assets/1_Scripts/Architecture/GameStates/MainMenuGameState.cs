using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.StateMachine;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _1_Scripts.Architecture.GameStates
{
    public class MainMenuGameState : GameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IUIService _uiService;
        private readonly EventsBus _eventsBus;
        
        public MainMenuGameState(GameStateMachine stateMachine, IUIService uiService, EventsBus eventsBus)
        {
            _stateMachine = stateMachine;
            _uiService = uiService;
            _eventsBus = eventsBus;
        }

        public void Enter()
        {
            _uiService.ShowWindow(WindowType.MainMenu);
            _eventsBus.OnClickPlayBtn += ToBattle;
        }

        public void Update()
        {
        }

        public void Exit()
        {
            _eventsBus.OnClickPlayBtn -= ToBattle;
        }
        
        private void ToBattle()
        {
            //_stateMachine.ChangeState(new MainMenuGameState());
        }
    }
}