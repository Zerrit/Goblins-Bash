using System;
using TMPro;
using UnityEngine;

namespace _1_Scripts.Enemies
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer healthBar;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private float maxBarSize = 3f;
        
        private int _maxHealth;
        private int _currentHealth;

        public void Initialize(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            healthBar.size = new Vector2(maxBarSize, healthBar.size.y);
            healthText.text = maxHealth.ToString();
        }

        public bool ReduceHealth(int damage)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            float i = (maxBarSize * _currentHealth) / _maxHealth;
            Vector2 newValue = new Vector2(i, healthBar.size.y);
            healthBar.size = newValue;
            healthText.text = _currentHealth.ToString();

            return _currentHealth == 0;
        }

        public bool Heal(int value)
        {
            _currentHealth += value;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            
            float i = (maxBarSize * _currentHealth) / _maxHealth;
            Vector2 newValue = new Vector2(i, healthBar.size.y);
            healthBar.size = newValue;
            healthText.text = _currentHealth.ToString();

            return _currentHealth == _maxHealth;
        }

        public void NullifyHealth()
        {
            ReduceHealth(_currentHealth);
        }
    }
}