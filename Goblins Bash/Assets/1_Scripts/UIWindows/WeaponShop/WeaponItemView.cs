using System;
using _1_Scripts.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1_Scripts.UIModules
{
    [RequireComponent(typeof(Image))]
    public class WeaponItemView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<WeaponItemView> OnClick;

        [SerializeField] private Image contentImage;
        [SerializeField] private Image lockImage;

        [SerializeField] private TextMeshProUGUI priceView;

        [SerializeField] private Image selectionText;
        
        [SerializeField] private Sprite standartBackground;
        [SerializeField] private Sprite highlightBackground;
        
        private Image _backGroundImage;

        public WeaponStaticData Item { get; private set; }
        public bool IsLock { get; private set; }
        public int Price => Item.Price;
        public GameObject Prefab => Item.Prefab.gameObject;


        public void Initialize(WeaponStaticData item)
        {
            _backGroundImage = GetComponent<Image>();
            _backGroundImage.sprite = standartBackground;
            Item = item;
            contentImage.sprite = item.Icon;
            priceView.text = item.Price.ToString();
        }

        public void OnPointerClick(PointerEventData eventData) => OnClick?.Invoke(this);

        public void Lock()
        {
            IsLock = true;
            lockImage.gameObject.SetActive(IsLock);
            priceView.gameObject.SetActive(IsLock);
        }
        public void Unlock()
        {
            IsLock = false;
            lockImage.gameObject.SetActive(IsLock);
            priceView.gameObject.SetActive(IsLock);
        }

        public void Select() => selectionText.gameObject.SetActive(true);
        public void Unselect() => selectionText.gameObject.SetActive(false);

        public void Highlight() => _backGroundImage.sprite = highlightBackground;
        public void Unhighlight() => _backGroundImage.sprite = standartBackground;
    }
}