using System;
using System.Collections.Generic;
using System.Linq;
using _1_Scripts.GameProgress;
using _1_Scripts.StaticData;
using _1_Scripts.UIModules.ArtifactsShop;
using UnityEngine;

namespace _1_Scripts.UIModules
{
    public class ArtifactPanel : MonoBehaviour
    {
        public event Action<ArtifactView> ArtifactViewClicked;
        public event Action<ArtifactView> ArtifactViewDoubleClicked;

        [SerializeField] private ArtifactView artifactViewPrefab;
        [SerializeField] private Transform contentPoint;

        private readonly List<ArtifactView> _artifactViews = new();
        

        public void Initialize(IEnumerable<Artifact> artifacts, ProgressService progressService)
        {
            Clear();
            
            foreach (Artifact artifact in artifacts)
            {
                ArtifactView instance = Instantiate(artifactViewPrefab, contentPoint);
                instance.Initialize(artifact);
                
                _artifactViews.Add(instance);
                instance.OnClick += OnArtifactViewClicked;

                if (progressService.PurchasedArtifacts.Contains(instance.ArtifactData.ArtifactId))
                {
                    instance.Unlock();
                    
                    if (progressService.SelectedArtifacts.Contains(instance.ArtifactData.ArtifactId))
                    {                 
                        ArtifactViewDoubleClicked?.Invoke(instance);
                        instance.Select();
                    }
                }
                else
                {
                    instance.Lock();
                    instance.Unselect();
                }
            }
        }

        private void OnArtifactViewClicked(ArtifactView artifactView)
        {
            ArtifactViewClicked?.Invoke(artifactView);
            artifactView.Highlight();
        }

        private void Clear()
        {
            foreach (ArtifactView artifact in _artifactViews)
            {
                artifact.OnClick -= OnArtifactViewClicked;
                Destroy(artifact.gameObject);
            }
            _artifactViews.Clear();
        }
    }
}