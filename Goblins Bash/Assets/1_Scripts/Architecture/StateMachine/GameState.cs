using UnityEngine;

namespace _1_Scripts.Architecture.StateMachine
{
    public abstract class GameState
    {
        protected float startTime;

        public virtual void Enter()
        {
            Debug.Log("Запущен этап - "+ nameof(GameState));
            startTime = Time.time;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {
            Debug.Log("Завершен этап - "+ nameof(GameState));
        }
    }
}