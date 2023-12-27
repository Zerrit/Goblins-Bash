using System.Collections.Generic;
using _1_Scripts.GameProgress;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.PlayerLogic
{
    public class ArtifactSystem
    {
        public List<Artifact> Artifacts { get; }
        
        public PlayerController Player { get; }
        private ProgressService _progressService;
        private IStaticDataService _staticDataService;


        public ArtifactSystem(ProgressService progressService, IStaticDataService staticDataService, PlayerController player)
        {
            Artifacts = new ();
            Player = player;

            LoadInstalledAtrifacts(progressService, staticDataService);
            ApplyArtifacts();
        }
        
        
        
        private void LoadInstalledAtrifacts(ProgressService progressService, IStaticDataService staticDataService)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(progressService.SelectedArtifacts[i]);
                if (progressService.SelectedArtifacts[i] != ArtifactsType.Empty)
                {
                    Artifacts.Add(staticDataService.GetDataFor(progressService.SelectedArtifacts[i]));
                }
            }
        }
        
        private void ApplyArtifacts()
        {
            foreach (Artifact artifact in Artifacts)
            {
                artifact.ApplyEffect(this);
            }
        }
    }
}