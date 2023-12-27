using System;
using _1_Scripts.StaticData.Upgrades;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1_Scripts.UIWindows
{
    [RequireComponent(typeof(Image))]
    public class UpgradeItemView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<Upgrade> OnClick;
        public bool isInteractive;

        [SerializeField] private Image upgradeImage;
        [SerializeField] private TextMeshProUGUI description;

        private Upgrade _upgrade;


        public void Initialize(Upgrade upgrade)
        {
            upgradeImage.sprite = upgrade.Icon;
            description.text = upgrade.Description;
            _upgrade = upgrade;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(!isInteractive) return;
            
            OnClick?.Invoke(_upgrade);
            transform.DOScale(new Vector3(.9f, .9f, 1f), 0.1f)
                .SetEase(Ease.InOutQuad)
                .SetLoops(2, LoopType.Yoyo);
        }
    }
}