using System;
using UnityEngine;

namespace _1_Scripts.PlayerLogic
{
    public class PlayerHealth
    {
        public event Action<float> HeathChanged;

        public int MaxHealth { get; private set; }
        public float HealthIndex { get; private set; }
        public int RegenerationValue { get; set; }
        
        private int _currentHealth;
        

        public PlayerHealth(int maxHealth)
        {
            MaxHealth = maxHealth;
            _currentHealth = MaxHealth;
        }
        
        
        
        public bool ReduceHealth(int damage)
        {
            _currentHealth -= damage;
            CommitHeathChange();
            return _currentHealth == 0;
        }

        public void IncreaseHealth(int value)
        {
            _currentHealth += value;
            CommitHeathChange();
        }
        
        public void IncreaseHealthByPercentage(float percent)
        {
            _currentHealth +=  (int)(MaxHealth * percent);
            CommitHeathChange();
        }

        
        public void ChangeMaxHealth(int addValue)
        {
            MaxHealth += addValue;
            _currentHealth += addValue;
            CommitHeathChange();
        }

        public void RegenerateHealth()
        {
            
        }
        
        private void CommitHeathChange()
        {
            _currentHealth = Mathf.Clamp(_currentHealth, 0, MaxHealth);
            HealthIndex = (float) _currentHealth / MaxHealth;
            HeathChanged?.Invoke(HealthIndex);
        }
    }
}