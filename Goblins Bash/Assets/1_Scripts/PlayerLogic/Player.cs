using System;
using System.Collections;
using _1_Scripts.WeaponsLogic;
using UnityEngine;
using Zenject;

namespace _1_Scripts.PlayerLogic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform weaponPoint; 
        
        private IPlayerController _playerController;
        private Transform _selfTransform;
        [SerializeField] private Camera playerCamera;


        
        [Inject]
        public void Construct(IPlayerController playerController)
        {
            _playerController = playerController;
            playerController.InitializePlayer(playerCamera, weaponPoint);
            
            playerController.OnMoveToNewPosition += MoveToNextLevel;
        }
        

        public void MoveToNextLevel(Transform target, Action onMoved)
        {
            StartCoroutine(LevelTransition(target.position, 2f, onMoved));
        }

        private IEnumerator LevelTransition(Vector3 newPos, float transitionTime, Action transitionEndAction)
        {
            float t = 0f;
            Vector3 startingPos = transform.position;

            while (t < 1)
            {
                t += Time.deltaTime / transitionTime;
                transform.position = Vector3.Lerp(startingPos, newPos, t);
                yield return null;
            }
            transitionEndAction?.Invoke();
        }


        private void OnDestroy()
        {
            _playerController.OnMoveToNewPosition -= MoveToNextLevel;
        }
        
        private void OnValidate()
        {
            if (_selfTransform == null)
                _selfTransform = transform;
        }
    }
}