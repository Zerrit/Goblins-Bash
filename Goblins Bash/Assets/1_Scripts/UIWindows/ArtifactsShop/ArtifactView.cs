using System;
using _1_Scripts.Items.Artifacts;
using _1_Scripts.StaticData;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1_Scripts.UIModules.ArtifactsShop
{
    public class ArtifactView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<ArtifactView> OnClick;

        [SerializeField] private Image artifactImage;
        [SerializeField] private Image selectedImage;
        [SerializeField] private Image lockImage;
        
        public bool IsLock { get; private set; }

        public Artifact ArtifactData { get; private set; }


        public void Initialize(Artifact artifactData)
        {
            ArtifactData = artifactData;
            artifactImage.sprite = artifactData.Icon;
        }
        
        
        
        public void OnPointerClick(PointerEventData eventData) => OnClick?.Invoke(this);

        
        public void Lock()
        {
            IsLock = true;
            lockImage.enabled = IsLock;
            artifactImage.color = Color.black;
        }
        
        public void Unlock()
        {
            IsLock = false;
            lockImage.enabled = IsLock;
            artifactImage.color = Color.white;
        }

        public void Highlight()
        {
            
        }

        public void UnhighLight()
        {
            
        }

        public void Select() => selectedImage.enabled = true;
        public void Unselect() => selectedImage.enabled = false;
    }
}