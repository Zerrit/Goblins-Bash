using _1_Scripts.StaticData.Upgrades;

namespace _1_Scripts.UIWindows
{
    public struct UpgradeItemStack
    {
        public Upgrade[] upgradeStack;
        
        public UpgradeItemStack(Upgrade[] upgrades)
        {
            upgradeStack = upgrades;
        }
    }
}