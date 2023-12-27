using System.Collections.Generic;
using _1_Scripts.Items.Artifacts;
using _1_Scripts.Logic;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    [CreateAssetMenu(fileName = "All Artifacts", menuName = "Create Artifacts/All Artifacts")]
    public class AllArtifactsData : ScriptableObject
    {
        [SerializeField] private List<Artifact> artifacts;

        public IEnumerable<Artifact> Artifacts => artifacts;
    }
}