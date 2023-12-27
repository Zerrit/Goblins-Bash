using System;

namespace _1_Scripts.UIWindows.Lose_Window
{
    public class LoseWindowController : ILoseWindowController
    {
        public event Action OnExitButtonClick;
        public event Action OnAdsButtonClick;
        public event Action OnRunResultUpdated;

        public LoseWindowController()
        {

        }

        
        public void UpdateRunResult()
        {
            OnRunResultUpdated?.Invoke();
        }

        public void FinishRun()
        {
            OnExitButtonClick?.Invoke();
        }
    }
}