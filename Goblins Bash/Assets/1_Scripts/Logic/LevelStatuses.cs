using System.Collections.Generic;
using _1_Scripts.Enemies;

namespace _1_Scripts.Logic
{
    public class LevelStatuses
    {
        private readonly Dictionary<StatusType, IStatusHandler> _statuses;

        public LevelStatuses()
        {
            _statuses = new();
        }
        
        
        public bool TryGetStatus(StatusType status)
        {
            if (_statuses.ContainsKey(status))
            {
                _statuses[status].OnStatusTriggered();
                return true;
            }
            return false;
        }

        
        public bool AddStatus(IStatusHandler statusHandler)
        {
            return (_statuses.TryAdd(statusHandler.StatusType, statusHandler));
        }

        public void RemoveStatus(StatusType status)
        {
            if (_statuses.ContainsKey(status)) _statuses.Remove(status);
        }
    }
}