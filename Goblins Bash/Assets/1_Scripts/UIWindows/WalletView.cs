using System;
using _1_Scripts.GameProgress;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace _1_Scripts.UIModules
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;
        private RectTransform _transform;

        private ISpendable _walletService;

        [Inject]
        public void Construct(ISpendable walletService)
        {
            _walletService = walletService;
            _transform = moneyText.rectTransform;
            UpdateValue(_walletService.GetCurrentMoney());
            
            _walletService.MoneyChanged += UpdateValue;
        }

        private void UpdateValue(int value)
        {
            _transform.DOPunchScale(new Vector3(.1f, .1f, 0f),.1f);
            moneyText.text = value.ToString();
        }

        private void OnDestroy()
        {
            _walletService.MoneyChanged -= UpdateValue;
        }
    }
}