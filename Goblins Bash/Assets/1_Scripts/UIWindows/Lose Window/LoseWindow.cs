using _1_Scripts.Architecture;
using _1_Scripts.UIModules;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _1_Scripts.UIWindows.Lose_Window
{
    public class LoseWindow: UIWindow
    {
        [SerializeField] private TextMeshProUGUI gold;
        [SerializeField] private TextMeshProUGUI kills;
        [SerializeField] private TextMeshProUGUI someText;
        [SerializeField] public Button homeButton;

        private ILoseWindowController _loseWindowController;

        [Inject]
        public void Construct(ILoseWindowController loseWindowController)
        {
            _loseWindowController = loseWindowController;
            homeButton.onClick.AddListener(FinishRun);
        }


        public override void Show()
        {
            base.Show();

            _loseWindowController.OnRunResultUpdated += UpdateResults;
        }
        
        public override void Hide()
        {
            _loseWindowController.OnRunResultUpdated -= UpdateResults;
            
            base.Hide();
        }
        
        
        
        
        private void UpdateResults()
        {
            
        }

        private void FinishRun()
        {
            _loseWindowController.FinishRun();
        }
    }
}