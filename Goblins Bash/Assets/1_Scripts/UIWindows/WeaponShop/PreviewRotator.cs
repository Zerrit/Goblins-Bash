using System;
using UnityEngine;

namespace _1_Scripts.Items
{
    public class PreviewRotator :MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float rotationSpeed;

        private float _currentRotation = 0;

        public void Update()
        {
            _currentRotation -= Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Euler(0f, _currentRotation, 0f);
        }

        public void ResetRotation() => _currentRotation = 0f;
    }
}