using System;
using System.Collections.Generic;
using _1_Scripts.Items;
using _1_Scripts.Items.ItemVisitors;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.UIModules
{
    public class ShopPanel : MonoBehaviour
    {
        public event Action<WeaponItemView> ItemViewClicked;
        
        [SerializeField] private Transform itemsParent;
        [SerializeField] private WeaponItemView itemsView;
        
        private readonly List<WeaponItemView> _shopItems = new();
        
        private PurchasedWeaponChecker _purchasedWeaponChecker;
        private SelectedWeaponChecker _selectedWeaponChecker;

        public void Initialize(PurchasedWeaponChecker purchasedWeaponChecker, SelectedWeaponChecker selectedWeaponChecker)
        {
            _purchasedWeaponChecker = purchasedWeaponChecker;
            _selectedWeaponChecker = selectedWeaponChecker;
        }

        public void Show(IEnumerable<WeaponStaticData> items)
        {
            Clear();
            
            foreach (WeaponStaticData item in items)
            {
                WeaponItemView weaponItemView = Instantiate(itemsView, itemsParent);
                weaponItemView.Initialize(item);

                weaponItemView.OnClick += OnWeaponViewClick;
                
                weaponItemView.Unselect();
                weaponItemView.Unhighlight();
                
                item.Accept(_purchasedWeaponChecker);
                if (_purchasedWeaponChecker.IsPurchaised)
                {
                    item.Accept(_selectedWeaponChecker);
                    if (_selectedWeaponChecker.IsSelected)
                    {
                        weaponItemView.Select();
                        weaponItemView.Highlight();
                        ItemViewClicked?.Invoke(weaponItemView);
                    }
                    
                    weaponItemView.Unlock();
                }
                else weaponItemView.Lock();
                
                _shopItems.Add(weaponItemView);
            }
        }

        public void Select(WeaponItemView weaponItemView)
        {
            foreach (WeaponItemView item in _shopItems)
            {
                item.Unselect();
            }
            weaponItemView.Select();
        }
        
        private void OnWeaponViewClick(WeaponItemView weaponItemView)
        {
            Highlight(weaponItemView);
            ItemViewClicked?.Invoke(weaponItemView);
        }

        private void Highlight(WeaponItemView weaponItemView)
        {
            foreach (WeaponItemView item in _shopItems)
            {
                item.Unhighlight();
            }
            weaponItemView.Highlight();
        }
        
        private void Clear()
        {
            foreach (WeaponItemView itemView in _shopItems)
            {
                itemView.OnClick -= OnWeaponViewClick;
                Destroy(itemView.gameObject);
            }
            _shopItems.Clear();
        }
    }
}