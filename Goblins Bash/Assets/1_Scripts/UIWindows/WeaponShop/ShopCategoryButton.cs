using System;
using UnityEngine;
using UnityEngine.UI;

namespace _1_Scripts.UIModules
{
    public class ShopCategoryButton : MonoBehaviour
    {
        public event Action Click;

        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color unselectedColor;

        private void OnEnable() => button.onClick.AddListener(OnClick);
        private void OnDisable() => button.onClick.RemoveListener(OnClick);

        public void Select() => image.color = selectedColor;
        public void Unselect() => image.color = unselectedColor;

        private void OnClick() => Click?.Invoke();
    }
}