using _1_Scripts.Logic;
using _1_Scripts.UIModules;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class BattleWindow : UIWindow
    {
        [SerializeField] private TMP_Text waveText;
        [SerializeField] private TMP_Text popUpText;

        private IWavesController _wavesController;

        
        [Inject]
        public void Construct(IWavesController wavesController)
        {
            _wavesController = wavesController;
        }

        
        
        public override void Show()
        {
            base.Show();

            _wavesController.OnWaveStarted += ShowWaveMassage;
        }

        public override void Hide()
        {
            _wavesController.OnWaveStarted -= ShowWaveMassage;
            base.Hide();
        }


        private void ShowWaveMassage(int waveNumber)
        {
            popUpText.text = "WAVE "+waveNumber+" STARTED";
            popUpText.enabled = true; 
            
            popUpText.rectTransform
                .DOScale(new Vector3(1f, 1f, 1f), .2f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    popUpText.rectTransform.DOScale(new Vector3(.2f, .2f, 1f), .1f)
                        .SetDelay(1.5f)
                        .OnComplete(() =>
                        {
                            popUpText.enabled = false; 
                            //onHide?.Invoke();
                        });
                });
        }
    }
}