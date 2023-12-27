using System;
using _1_Scripts.StaticData.Upgrades;

namespace _1_Scripts.UIWindows
{
    public interface IUpgradeSystem
    {
        public event Action OnUpgradeFinished;
        public event Action<UpgradeItemStack> OnUpgradeStackUpdated;

        public void UpdateStack();
        public void ApplyUpgrade(Upgrade selectedUpgrade);
    }
}