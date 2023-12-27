using System.Collections.Generic;
using _1_Scripts.GameProgress;
using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Enemies
{
    public class EnemiesFactory
    {
        private readonly IReadOnlyList<GoblinStaticData> _goblins;
        private readonly LevelStatuses _statuses;
        private readonly IPlayerDamageable _player;
        private readonly IRewardable _rewardService;
        
        public EnemiesFactory(IStaticDataService staticDataService, IPlayerDamageable player, IRewardable rewardService)
        {
            _goblins = staticDataService.Goblins;
            _player = player;
            _rewardService = rewardService;
        }

        public Goblin GetGoblin(int id, Transform parentPoint)
        {
            Goblin goblin = Object.Instantiate(_goblins[id].prefub, parentPoint);
          
            goblin.Initialize(_player, _rewardService, _goblins[id].placementType, _goblins[id].damage, _goblins[id].health, 
                _goblins[id].maxCharge, _goblins[id].defaultCharge, _goblins[id].reward);
            
            return goblin;
        }
    }
}