using System;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using _1_Scripts.StaticData.Upgrades;

namespace _1_Scripts.UIWindows
{
    public class UpgradeSystem : IUpgradeSystem
    {
        public event Action OnUpgradeFinished;
        public event Action<UpgradeItemStack> OnUpgradeStackUpdated;
        
        private readonly Upgrade[] _upgradeItemStack;
        
        private readonly IPlayerController _player;
        private readonly IStaticDataService _staticDataService;
        
        
        public UpgradeSystem(IPlayerController player, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _player = player;
            _upgradeItemStack = new Upgrade[3];
        }
        
        
        public void UpdateStack()
        {
            for (int i = 0; i < 3; i++)
            {
                int upgradeId = UnityEngine.Random.Range(0, _staticDataService.Upgrades.Count); 
                _upgradeItemStack[i] = _staticDataService.Upgrades[upgradeId];
            }
            
            OnUpgradeStackUpdated?.Invoke(new UpgradeItemStack(_upgradeItemStack));
        }

        public void ApplyUpgrade(Upgrade selectedUpgrade)
        {
            selectedUpgrade.ApplyEffect(_player);
            OnUpgradeFinished?.Invoke();
        }
    }
}