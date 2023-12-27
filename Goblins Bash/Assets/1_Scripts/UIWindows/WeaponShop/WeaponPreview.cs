using _1_Scripts.Items;
using UnityEngine;

namespace _1_Scripts.UIModules
{
    public class WeaponPreview : MonoBehaviour
    {
        private const string RenderLayer = "WeaponPreviewRender";
        
        [SerializeField] private PreviewRotator rotator;
        private GameObject _currentModel;

        public void InstantiateModel(GameObject model)
        {
            if(_currentModel != null)
                Destroy(_currentModel);
            
            rotator.ResetRotation();
            _currentModel = Instantiate(model, transform);

            Transform[] childrens = _currentModel.GetComponentsInChildren<Transform>();

            foreach (Transform child in childrens)
            {
                child.gameObject.layer = LayerMask.NameToLayer(RenderLayer);
            }
        }
    }
}