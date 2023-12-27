using System;
using DG.Tweening;
using UnityEngine;

namespace _1_Scripts.Enemies
{
    public class ChargeBar : MonoBehaviour
    {
        private int _maxCharges;
        private int _defaultCharge;
        private int _charge;
        private float _chargeTimer;
        private bool _isCharging;
        private Action _onFullCharge;
        
        [SerializeField] private SpriteRenderer[] charges;


        public void Initialize(int maxCharges, int defaultCharge, Action onFullCharge)
        {
            _maxCharges = maxCharges;
            _defaultCharge = defaultCharge;
            _charge = _defaultCharge;
            _isCharging = false;
            _onFullCharge = onFullCharge;

            for (int i = 0; i < _maxCharges; i++)
            {
                if(i < defaultCharge) charges[i].color = Color.white;
                else charges[i].color = Color.gray;
            }
        }

        private void Update()
        {
            Charging();
        }

        public bool CheckCharge()
        {
            return (_charge >= _maxCharges);
        }

        private void Charging()
        {
            if(!_isCharging) return;

            _chargeTimer += Time.deltaTime;
            if (_chargeTimer >= 1.0f)
            {
                IncreaseCharge();
                ResetChargeTimer();
            }

            if (CheckCharge())
            {
                StopCharging();
                _onFullCharge?.Invoke();
            }
        }

        private void Knockouting()
        {
            _chargeTimer += Time.deltaTime;
            if(_chargeTimer >= 2f) StartCharging();
        }
        
        public void StartCharging() => _isCharging = true;
        public void StopCharging() => _isCharging = false;
        public void ResetChargeTimer() => _chargeTimer = 0;
        public void ChangeCallBack(Action onFullCharg) => _onFullCharge = onFullCharg;



        public void IncreaseCharge()
        {
            if(_charge == _maxCharges) return;
            
            _charge++;
            charges[_charge-1].color = Color.white;
            charges[_charge - 1].transform.DOPunchScale(new Vector3(.12f,.12f,1f), .2f);
        }
        public void IncreaseCharge(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if(_charge == _maxCharges) return;
                _charge++;
                charges[_charge - 1].color = Color.white;
                charges[_charge - 1].transform.DOPunchScale(new Vector3(.12f, .12f, 1f), .2f);
            }
        }
        
        
        public void ReduceCharge()
        {
            ResetChargeTimer();
            if(_charge == 0) return;
            
            _charge--;
            charges[_charge].color = Color.gray;
        }
        public void ReduceCharge(int count)
        {
            ResetChargeTimer();
            for (int i = 0; i < count; i++)  
            {
                if(_charge == 0) return;
                
                _charge--;
                charges[_charge].color = Color.gray;
            }
        }

        
        public void ReduceChargeToDefault()
        {
            ReduceCharge(_maxCharges - _defaultCharge);
        }
        public void IncreaseChargeToDefault()
        {
            IncreaseCharge(_defaultCharge);
        }
    }
}
