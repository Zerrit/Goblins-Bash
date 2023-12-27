using System;
using DG.Tweening;
using UnityEngine;

namespace _1_Scripts.Logic
{
    public class Place : MonoBehaviour
    {
        [SerializeField] private PlaceType placeType;
        [SerializeField] private Vector3 appearDirection;
        public PlaceType PlaceType => placeType;
        public Transform PlaceTransform; //{ get; private set; }


        public void Show(Action onSnow)
        {
            PlaceTransform.DOMove(PlaceTransform.position + appearDirection, 0.25f).OnComplete(() => onSnow());
        }

        public void Hide(Action onHide)
        {
            PlaceTransform.DOMove(PlaceTransform.position - appearDirection, 0.25f).OnComplete(() => onHide());
        }

        private void OnValidate()
        {
            PlaceTransform = GetComponent<Transform>();
        }

    }
}
