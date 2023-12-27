using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _1_Scripts.Items
{
    public class BuyButton : MonoBehaviour
    {
        public event Action Click;
        
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;

        [SerializeField] private Color lockedColor;
        [SerializeField] private Color unlockedColor;

        [SerializeField] private float lockAnimationDuration;
        [SerializeField] private float lockAnimationStrange;

        private bool _isLock;

        private void OnEnable() => button.onClick.AddListener(OnButtonClick);

        public void UpdateText(int price) => text.text = price.ToString();

        private void OnButtonClick()
        {
            if (_isLock)
            {
                transform.DOShakePosition(lockAnimationDuration, lockAnimationStrange);
                return;
            }
            Click?.Invoke();
        }

        public void Lock()
        {
            _isLock = true;
            text.color = lockedColor;
        }

        public void Unlock()
        {
            _isLock = false;
            text.color = unlockedColor;
        }

        private void OnDisable() => button.onClick.RemoveListener(OnButtonClick);
    }
}