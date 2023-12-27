using _1_Scripts.Items.Artifacts;
using _1_Scripts.PlayerLogic;
using UnityEngine;

namespace _1_Scripts.StaticData
{
    public abstract class Artifact : ScriptableObject
    {
        [field:SerializeField] public ArtifactsType ArtifactId { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
        [field:SerializeField] public string UnlockCondition { get; private set; }
        [field:SerializeField] public int Price { get; private set; }


        public abstract void ApplyEffect(ArtifactSystem artifactSystem);
    }
}