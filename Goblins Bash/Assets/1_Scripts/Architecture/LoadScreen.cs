using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _1_Scripts.Architecture
{
    public class LoadScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image curtain;


        public void Show()
        {
            gameObject.SetActive(true);
            canvasGroup.DOFade(1f, .2f);
        }
        
        public void Hide()
        {
            canvasGroup.DOFade(0f, .2f)
                .OnComplete(() => 
                    gameObject.SetActive(false));
        }
    }
}