using System;
using System.Collections.Generic;
using _1_Scripts.Architecture.GameStates;
using _1_Scripts.UIModules;

namespace _1_Scripts.Architecture.StateMachine
{
    public class GameStateMachine
    {
        public GameState CurrentGameState { get; private set; }
        
        
        public void Initialize(GameState newState)
        {
            CurrentGameState = newState;
            CurrentGameState.Enter();
        }

        public void ChangeState(GameState newState)
        {
            CurrentGameState.Exit();
            CurrentGameState = newState;
            CurrentGameState.Enter();
        }
        
 
        //private readonly Dictionary<Type, GameState> _gameStates;

        //public GameStateMachine()
        //{
            /*_gameStates = new Dictionary<Type, GameState>()
            {
                [typeof(PrepeareState)] = new PrepeareState(this, uiService, eventsBus),
                [typeof(BattleState)] = new BattleState(this, uiService, eventsBus),
                [typeof(PlayerUpgradeState)] = new PlayerUpgradeState(this, eventsBus, uiService),
                [typeof(LoseGameState)] = new LoseGameState(this, eventsBus, uiService),
            };*/
       // }

        /*public void Initialize<TGameState>() where TGameState : GameState
        {
            CurrentGameState = _gameStates[typeof(TGameState)];
            CurrentGameState.Enter();
        }

        public void ChangeState<TGameState>() where TGameState : GameState
        {
            CurrentGameState.Exit();
            CurrentGameState = _gameStates[typeof(TGameState)];
            CurrentGameState.Enter();
        }*/
        

    }
}