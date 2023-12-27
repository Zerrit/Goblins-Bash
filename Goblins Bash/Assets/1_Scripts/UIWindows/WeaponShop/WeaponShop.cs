using _1_Scripts.GameProgress;
using _1_Scripts.Items;
using _1_Scripts.Items.ItemVisitors;
using _1_Scripts.StaticData;
using _1_Scripts.UIModules;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class WeaponShop : UIWindow
    {
        [SerializeField] private Button backButton;
        [SerializeField] private ShopCategoryButton meleeCategoryButton;
        [SerializeField] private ShopCategoryButton rangeCategoryButton;

        [SerializeField] private ShopPanel shopPanel;
        [SerializeField] private WeaponPreview weaponPreview;
        
        [SerializeField] private BuyButton buyButton;
        [SerializeField] private Button selectionButton;
        [SerializeField] private Image selectedImage;


        private WeaponItemView _previewedWeaponItem;
        
        private IStaticDataService _staticDataService;
        private ISpendable _walletService;
        private PurchasedWeaponChecker _purchasedWeaponChecker;
        private SelectedWeaponChecker _selectedWeaponChecker;
        private WeaponSelector _weaponSelector;
        private WeaponUnlocker _weaponUnlocker;
        
        

        [Inject]
        public void Construct(IUIService uiService, ISpendable walletService, IStaticDataService staticDataService, ProgressService progressService)
        {
            backButton.onClick.AddListener(() => uiService.ReplaceWindow(WindowType.MainMenu));
            
            _staticDataService = staticDataService;
            _walletService = walletService;
            
            _purchasedWeaponChecker = new PurchasedWeaponChecker(progressService);
            _selectedWeaponChecker = new SelectedWeaponChecker(progressService);
            _weaponSelector = new WeaponSelector(progressService);
            _weaponUnlocker = new WeaponUnlocker(progressService);
        }
        
        public override void Show()
        {
            base.Show();
            meleeCategoryButton.Click += OnMeleeCategoryButtonClick;
            rangeCategoryButton.Click += OnRangeCategoryButtonClick;
            shopPanel.ItemViewClicked += OnItemViewClicked;
            buyButton.Click += OnBuyButtonClick;
            selectionButton.onClick.AddListener(OnSelectionButtonClick);

            shopPanel.Initialize(_purchasedWeaponChecker, _selectedWeaponChecker);
            OnMeleeCategoryButtonClick();
        }

        private void OnItemViewClicked(WeaponItemView weaponItemView)
        {
            _previewedWeaponItem = weaponItemView;
            weaponPreview.InstantiateModel(weaponItemView.Prefab);
            weaponItemView.Item.Accept(_purchasedWeaponChecker);

            if (_purchasedWeaponChecker.IsPurchaised)
            {
                weaponItemView.Item.Accept(_selectedWeaponChecker);
                if (_selectedWeaponChecker.IsSelected)
                {
                    ShowSelectedImage();
                    return;
                }

                ShowSelectionButton();
            }
            else ShowBuyButton(_previewedWeaponItem.Price);
        }

        private void OnBuyButtonClick()
        {
            if (_walletService.IsEnough(_previewedWeaponItem.Price))
            {
                _walletService.SpendMoney(_previewedWeaponItem.Price);
                _previewedWeaponItem.Item.Accept(_weaponUnlocker);
                SelectItem();
                _previewedWeaponItem.Unlock();
            }
        }

        private void OnSelectionButtonClick()
        {
            SelectItem();
        }

        private void OnMeleeCategoryButtonClick()
        {
            meleeCategoryButton.Select();
            rangeCategoryButton.Unselect();
            shopPanel.Show(_staticDataService.MeleeWeapons);
        }
        
        private void OnRangeCategoryButtonClick()
        {
            rangeCategoryButton.Select();
            meleeCategoryButton.Unselect();
            shopPanel.Show(_staticDataService.RangeWeapons);
        }

        private void SelectItem()
        {
            _previewedWeaponItem.Item.Accept(_weaponSelector);
            shopPanel.Select(_previewedWeaponItem);
            ShowSelectedImage();
        }
        
        private void ShowSelectionButton()
        {
            selectionButton.gameObject.SetActive(true);
            HideBuyButton();
            HideSelectedImage();
        }

        private void ShowSelectedImage()
        {
            selectedImage.gameObject.SetActive(true);
            HideSelectionButton();
            HideBuyButton();
        }

        private void ShowBuyButton(int price)
        {
            buyButton.gameObject.SetActive(true);
            buyButton.UpdateText(price);
            
            if(_walletService.IsEnough(price)) 
                buyButton.Unlock();
            else
                buyButton.Lock();
            
            
            HideSelectedImage();
            HideSelectionButton();
        }

        private void HideBuyButton() => buyButton.gameObject.SetActive(false);
        private void HideSelectionButton() => selectionButton.gameObject.SetActive(false);
        private void HideSelectedImage() => selectedImage.gameObject.SetActive(false);


        public override void Hide()
        {
            base.Hide();
            meleeCategoryButton.Click -= OnMeleeCategoryButtonClick;
            rangeCategoryButton.Click -= OnRangeCategoryButtonClick;
            shopPanel.ItemViewClicked -= OnItemViewClicked;
            buyButton.Click -= OnBuyButtonClick;
            selectionButton.onClick.RemoveListener(OnSelectionButtonClick);
        }
    }
}