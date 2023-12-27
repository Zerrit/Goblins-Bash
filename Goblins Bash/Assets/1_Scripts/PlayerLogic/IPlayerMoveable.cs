using System;
using UnityEngine;

namespace _1_Scripts.PlayerLogic
{
    public interface IPlayerMoveable
    {
        public void MoveToNextLevel(Transform target, Action onMoved);
    }
}