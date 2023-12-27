using System;
using _1_Scripts.Architecture.StateMachine;

namespace _1_Scripts.StateMachine
{
    public class StateMachine<T> where T: GameState
    {
        public T CurrentState { get; private set; }

        public virtual void Initialize(T state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        public virtual void ChangeState(T nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            CurrentState.Enter();
        }
    }
}