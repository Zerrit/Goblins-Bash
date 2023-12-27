using System;
using System.Collections.Generic;
using _1_Scripts.Enemies.Goblins;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _1_Scripts.Logic
{
    public class Level : MonoBehaviour
    {
        [field: SerializeField] public Transform SnapTransform { get; private set; }
        [field: SerializeField] public Transform StayPosition { get; private set; }
        [field: SerializeField] public Place SafePlace { get; private set; }
        
        [SerializeField] private List<Place> emptyMeleePlaces = new();
        [SerializeField] private List<Place> emptyRangePlaces = new(); 
        
        public LevelStatuses Statuses { get; private set; }
        
        private int _emptyRangePlacesCount = 4;
        private int _emptyMeleePlacesCount = 4;

        
        private void Start()
        {
            _emptyRangePlacesCount = emptyRangePlaces.Count;
            _emptyMeleePlacesCount = emptyMeleePlaces.Count;
            Statuses = new LevelStatuses();
        }

        
        
        // РАБОТА С УРОВНЕМ
        public bool GetPlace(ref Place place, EnemyPlacementType placementType)
        {
            return placementType switch
            {
                EnemyPlacementType.Melee => GetMeleePlace(ref place),
                EnemyPlacementType.Range => GetRangePlace(ref place),
                EnemyPlacementType.Agile => GetAnyPlace(ref place),
                _ => false
            };
        }
        
        public bool GetMeleePlace(ref Place place)
        {
            if (_emptyMeleePlacesCount <= 0) return false;
            
            place = emptyMeleePlaces[Random.Range(0, _emptyMeleePlacesCount)];
            emptyMeleePlaces.Remove(place);
            _emptyMeleePlacesCount--;
            return true;
        }
        public bool GetRangePlace(ref Place place)
        {
            if (_emptyRangePlacesCount <= 0) return false;
            
            place = emptyRangePlaces[Random.Range(0, _emptyRangePlacesCount)];
            emptyRangePlaces.Remove(place);
            _emptyRangePlacesCount--;
            return true;
        }
        public bool GetAnyPlace(ref Place place)
        {
            int index = Random.Range(0, 2);
            if (index == 0)
            {
                if (GetMeleePlace(ref place))
                    return true;
                return GetRangePlace(ref place);
            }
            else
            {
                if (GetRangePlace(ref place))
                    return true;
                return GetMeleePlace(ref place);
            }
        }
        
        public void ReturnPlace(Place place)
        {
            if (place.PlaceType == PlaceType.Melee)
            {
                emptyMeleePlaces.Add(place);
                _emptyMeleePlacesCount++;
            }
            else if(place.PlaceType == PlaceType.Range)
            {
                emptyRangePlaces.Add(place);
                _emptyRangePlacesCount++;
            }
        }
    }
}
    