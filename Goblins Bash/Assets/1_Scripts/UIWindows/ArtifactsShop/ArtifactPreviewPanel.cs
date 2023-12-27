using _1_Scripts.Items.Artifacts;
using TMPro;
using UnityEngine;

namespace _1_Scripts.UIModules.ArtifactsShop
{
    public class ArtifactPreviewPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text artifactName;
        [SerializeField] private TMP_Text artifactDescription;

        public void SetData(ArtifactView view)
        {
            artifactName.text = view.ArtifactData.name;
            artifactDescription.text =
                (view.IsLock) ? view.ArtifactData.UnlockCondition : view.ArtifactData.Description;
        }
    }
}