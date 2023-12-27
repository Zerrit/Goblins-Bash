using System.Collections.Generic;
using _1_Scripts.StaticData.Upgrades;
using _1_Scripts.UIModules;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class UpgradeWindow : UIWindow
    {
        [SerializeField] private List<UpgradeItemView> upgradeViews;

        private IUpgradeSystem _upgradeSystem;


        [Inject]
        public void Construct(IUpgradeSystem upgradeSystem)  
        {
            _upgradeSystem = upgradeSystem;
        }

        
        private void UpdateData(UpgradeItemStack newStack)
        {
            for (int i = 0; i < 3; i++)
            {
                upgradeViews[i].Initialize(newStack.upgradeStack[i]);
                upgradeViews[i].OnClick += OnUpgradeSelected;
                upgradeViews[i].isInteractive = true;
            }
        }

        private void OnUpgradeSelected(Upgrade selectedUpgrade)
        {
            foreach (UpgradeItemView upgrade in upgradeViews)
            {
                upgrade.isInteractive = false;
                upgrade.OnClick -= OnUpgradeSelected;
            }
            
            _upgradeSystem.ApplyUpgrade(selectedUpgrade);
        }


        public override void Show()
        {
            base.Show();

            _upgradeSystem.OnUpgradeStackUpdated += UpdateData;
            transform.DOScale(Vector3.one, .3f).From(Vector3.zero).SetEase(Ease.InCubic);
        }

        public override void Hide()
        {
            _upgradeSystem.OnUpgradeStackUpdated -= UpdateData;
            transform.DOScale(Vector3.zero, .3f).OnComplete(() =>
            {
                base.Hide();
            });
        }
    }
}