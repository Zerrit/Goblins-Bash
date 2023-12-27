using System;

namespace _1_Scripts.Architecture
{
    public class EventsBus
    {
        // СОБЫТИЯ ОСНОВНОГО ИГРОВОГО ЦИКЛА
        public event Action OnStartLevel; // ПОДГОТОВКА НОВОГО УРОВНЯ
        public void InvokeStartLevelEvent() => OnStartLevel?.Invoke();

        public event Action OnCompleteLevel; // ЗАВЕРШЕНИЕ УРОВНЯ
        public void InvokeCompleteLevelEvent() => OnCompleteLevel?.Invoke();


        public event Action OnUpgradeSelected; // АПГРЕЙД ВЫБРАН
        public void InvokeUpgradeSelectedEvent() => OnUpgradeSelected?.Invoke();
        
        
        
        public event Action OnPlayerDefeated; // ПОРАЖЕНИЕ
        public void InvokeDefeatPlayerEvent() => OnPlayerDefeated?.Invoke();
        
        
        
        
        // ГЛОБАЛЬНЫЕ СОБЫТИЯ
        public event Action OnClickPlayBtn; // В БОЙ
        public void InvokeClickPlayBtnEvent() => OnClickPlayBtn?.Invoke();
        
        public event Action OnClickHomeBtn; // В МЕНЮ
        public void InvokeClickHomeBtnEvent() => OnClickHomeBtn?.Invoke();
        
    }
}