using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1_Scripts.UIModules.ArtifactsShop
{
    public class ArtifactCellView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<ArtifactCellView> OnClick;

        [SerializeField] private Transform cell;
        [SerializeField] private Image artifactImage;
        [SerializeField] private Image lockImage;

        public bool IsOccupied { get; private set; }
        public ArtifactView InstalledArtifact { get; private set; }
        private bool _isLock;

        

        public void OnPointerClick(PointerEventData eventData) => OnClick?.Invoke(this);
        
        
        
        public void InstallArtifact(ArtifactView artifactView)
        {
            InstalledArtifact = artifactView;
            IsOccupied = true;

            if (artifactView != null)
            {
                artifactImage.sprite = artifactView.ArtifactData.Icon;
                artifactImage.gameObject.SetActive(true);
            }
        }

        
        
        public void UninstallArtifact()
        {
            ClearCell();
            Unselect();
            
        }

        public void ClearCell()
        {
            artifactImage.gameObject.SetActive(false);
            InstalledArtifact.Unselect();
            IsOccupied = false;
        }

        
        
        public void Select()
        {
            cell.DOScale(new Vector3(1.1f, 1.1f, 1f), .1f);
        }

        public void Unselect()
        {
            cell.DOScale(Vector3.one, .1f);
        }
        
        
        
        
        public void LockCell()
        {
            
        }

        public void UnlockCell()
        {
            
        }
    }
}