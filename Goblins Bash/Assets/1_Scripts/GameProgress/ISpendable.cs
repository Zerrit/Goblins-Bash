using System;

namespace _1_Scripts.GameProgress
{
    public interface ISpendable
    {
        public event Action<int> MoneyChanged;
        public int GetCurrentMoney();
        public bool IsEnough(int price);
        public void SpendMoney(int money);
    }
}