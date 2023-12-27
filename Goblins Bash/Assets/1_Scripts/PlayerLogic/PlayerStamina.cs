using UnityEngine;

namespace _1_Scripts.PlayerLogic
{
    public class PlayerStamina
    {
        private float _maxStamina;
        private float _decreaseRate;
        private float _increaseRate;
        private float _currentStamina;

        public bool isShieldActive;
        public float StaminaIndex => _currentStamina / _maxStamina;
        
        
        
        public PlayerStamina(float maxStamina, float reduceRate, float increaseRate)
        {
            _maxStamina = maxStamina;
            _currentStamina = _maxStamina;
            _decreaseRate = reduceRate;
            _increaseRate = increaseRate;
        }


        public void ProcessStamina()
        {
            if(isShieldActive) DecreaseStamina();
            else IncreaseStamina();
        }
        
        private void DecreaseStamina()
        {
            _currentStamina -= _decreaseRate * Time.deltaTime;
            _currentStamina = Mathf.Clamp(_currentStamina, 0f, _maxStamina);

            if (_currentStamina <= 0f)
            {
                isShieldActive = false;
            }
        }

        private void IncreaseStamina()
        {
            _currentStamina += _increaseRate * Time.deltaTime;
            _currentStamina = Mathf.Clamp(_currentStamina, 0f, _maxStamina);
        }
    }
}