using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using UnityEngine;

namespace _1_Scripts.Items.Artifacts
{
    [CreateAssetMenu(fileName = "Extract Of Life", menuName = "Create Artifacts/Extract Of Life")]
    public class ExtractOfLife : Artifact
    {
        [SerializeField] private int regenerationValue;
        
        public override void ApplyEffect(ArtifactSystem artifactSystem)
        {
            artifactSystem.Player.PlayerHealth.RegenerationValue = regenerationValue;
        }
    }
}