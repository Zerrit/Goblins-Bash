using _1_Scripts.StaticData;

namespace _1_Scripts.Items.ItemVisitors
{
    public interface IItemVisitor
    {

        void Visit(WeaponStaticData item);
        void Visit(MeleeWeaponStaticData meleeStaticData);
        void Visit(RangeWeaponStaticData rangeStaticData);
    }
}