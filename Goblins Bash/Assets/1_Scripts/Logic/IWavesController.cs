using System;

namespace _1_Scripts.Logic
{
    public interface IWavesController
    {
        public event Action<int> OnStartLevel;
        public event Action<int> OnWaveStarted; 
        public event Action OnWavesOver;
        public void StartLevel(Level newLevel, int levelId);
        public void StopWave();
    }
}