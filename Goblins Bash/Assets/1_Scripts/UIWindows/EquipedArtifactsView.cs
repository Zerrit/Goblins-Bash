using _1_Scripts.Items.Artifacts;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _1_Scripts.UIModules
{
    public class EquipedArtifactsView : MonoBehaviour
    {
        [SerializeField] private Image[] artifactPlaces = new Image[3];

        [Inject]
        public void Construct(ArtifactSystem artifactSystem)
        {
            foreach (Artifact artifact in artifactSystem.Artifacts)
            {
                Image place = GetFreeArtifactPlace();
                place.sprite = artifact.Icon;
                place.enabled = true;
            }
        }

        private Image GetFreeArtifactPlace()
        {
            foreach (Image place in artifactPlaces)
            {
                if(place.enabled == false) return place;
            }

            return null;
        }
    }
}