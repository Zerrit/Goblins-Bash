using _1_Scripts.UIModules;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class PauseWindow : UIWindow
    {
        [SerializeField] private TextMeshProUGUI pauseText;
        
        [Inject]
        public void Construct(IUIService uiService)
        {
            uiService.RegisterModule(this);
            pauseText.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), 1f).SetLoops(-1, LoopType.Yoyo);
        }


        public override void Show()
        {
            base.Show();
            pauseText.rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), 1f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}