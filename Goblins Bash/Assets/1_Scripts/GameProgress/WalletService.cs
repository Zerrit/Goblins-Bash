using System;
using _1_Scripts.Architecture;

namespace _1_Scripts.GameProgress
{
    public class WalletService : IRewardable, ISpendable
    {
        public event Action<int> MoneyChanged;
        
        private readonly IPersistentData _persistendData;
        private readonly IDataProvider _dataProvider;
        private readonly EventsBus _eventsBus;
        
        public WalletService(IPersistentData persistendData, IDataProvider dataProvider, EventsBus eventsBus)
        {
            _persistendData = persistendData;
            _dataProvider = dataProvider;
            _eventsBus = eventsBus;

            _eventsBus.OnClickHomeBtn += SaveBattleReward;
        }


        public int GetCurrentMoney() => _persistendData.Progress.money;

        
        public void AddMoney(int money)
        {
            if (money < 0)
            {
                throw new ArgumentException(nameof(money));
            }
            _persistendData.Progress.money += money;
            MoneyChanged?.Invoke(_persistendData.Progress.money);
        }

        public bool IsEnough(int price)
        {
            if (price < 0) throw new ArgumentException(nameof(price));
            return _persistendData.Progress.money > price;
        }

        public void SpendMoney(int money)
        {
            if (money < 0) throw new ArgumentException(nameof(money));
            
            _persistendData.Progress.money -= money;
            _dataProvider.Save();
            MoneyChanged?.Invoke(_persistendData.Progress.money);
        }
        
        private void SaveBattleReward() => _dataProvider.Save();
    }
}