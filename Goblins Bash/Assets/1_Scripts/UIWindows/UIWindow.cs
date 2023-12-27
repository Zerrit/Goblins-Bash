using UnityEngine;

namespace _1_Scripts.UIWindows
{
    public abstract class UIWindow : MonoBehaviour
    {
        [field:SerializeField] public WindowType Type { get; private set; }

        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);

        public void DestroySelf() =>  Destroy(gameObject);
    }
}