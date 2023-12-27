using System;
using _1_Scripts.PlayerLogic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class PlayerHudView : UIWindow
    {
        [SerializeField] private EventTrigger shieldButton;
        [SerializeField] private Button switchWeaponBtn;
        [SerializeField] private Image unchoosenWeapon;
        
        [SerializeField] private RectTransform playerHealth;
        [SerializeField] private Slider shieldStamina;
        [SerializeField] private RectTransform shieldIcon;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private Image[] projectileChargeImage;

        private IPlayerController _player;
        
        
        [Inject]
        public void Construct(IPlayerController player)
        {
            _player = player;
            
            UpdatePlayerHealth();
            
            AddShieldButtonListeners(_player.SwitchShieldStatus);
            switchWeaponBtn.onClick.AddListener(_player.SwitchWeapon);
        }

        public override void Show()
        {
            base.Show();
            
            Subscribe();    
        }

        public override void Hide()
        {
            Unsubscribe();
            
            base.Hide();
        }
        
        
        private void Update()
        {
            shieldStamina.value = _player.PlayerStamina.StaminaIndex;
            if(shieldStamina.value == 0) UpdateShieldUI(false);
        }

        private void AddShieldButtonListeners(Action<bool> listener)
        {
            EventTrigger.Entry clickDown = new EventTrigger.Entry() {eventID = EventTriggerType.PointerDown};
            EventTrigger.Entry clickUp = new EventTrigger.Entry() {eventID = EventTriggerType.PointerUp};
            clickDown.callback.AddListener(_ => listener(true));
            clickUp.callback.AddListener(_ => listener(false));
            shieldButton.triggers.Add(clickDown);
            shieldButton.triggers.Add(clickUp);
        }

        private void UpdateWeaponUI()
        {
            Sprite buffer = switchWeaponBtn.image.sprite;
            switchWeaponBtn.image.sprite = unchoosenWeapon.sprite;
            unchoosenWeapon.sprite = buffer;
            switchWeaponBtn.image.rectTransform.DOPunchScale(new Vector3(.2f,.2f,0f), .2f);
        }
        
        private void UpdateShieldUI(bool isActive)
        {
            if (isActive)
            {
                shieldIcon.gameObject.SetActive(true);
                shieldIcon.DOScale(new Vector3(1f, 1f, 1f), .1f)
                    .From(Vector3.zero);
            }
            else
            {
                shieldIcon.DOScale(Vector3.zero, .1f)
                    .OnComplete(() => shieldIcon.gameObject.SetActive(false));
            }
        }
        
        private void UpdatePlayerHealth(float valueIndex = 1f)
        {
            healthText.text = (valueIndex * _player.PlayerHealth.MaxHealth + " / " + _player.PlayerHealth.MaxHealth + " HP");
            var sizeDelta = playerHealth.sizeDelta;
            float width = sizeDelta.x * valueIndex;
            playerHealth.sizeDelta = new Vector2(width, sizeDelta.y);
        }

        private void UpdateProjectileCount(int count)
        {
            for (int i = 0; i < 5; i++)
            {
                projectileChargeImage[i].enabled = (i < count);
            }
        }
        
        

        private void Subscribe()
        {
            _player.PlayerHealth.HeathChanged += UpdatePlayerHealth;
            _player.OnWeaponSwitched += UpdateWeaponUI;
            _player.OnShieldStatusSwitched += UpdateShieldUI;
            _player.WeaponController.RangeWeapon.OnArrowCountChanged += UpdateProjectileCount;
        }

        private void Unsubscribe()
        {
            _player.PlayerHealth.HeathChanged -= UpdatePlayerHealth;
            _player.OnWeaponSwitched -= UpdateWeaponUI;
            _player.OnShieldStatusSwitched -= UpdateShieldUI;
            _player.WeaponController.RangeWeapon.OnArrowCountChanged -= UpdateProjectileCount;
        }
    }
}