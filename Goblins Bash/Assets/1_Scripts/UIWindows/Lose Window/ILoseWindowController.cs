using System;

namespace _1_Scripts.UIWindows.Lose_Window
{
    public interface ILoseWindowController
    {
        event Action OnExitButtonClick;
        event Action OnAdsButtonClick;
        event Action OnRunResultUpdated;
        
        void UpdateRunResult();
        void FinishRun();
    }
}