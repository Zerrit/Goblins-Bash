using _1_Scripts.Audio;
using _1_Scripts.UIModules;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class SettingsWindow : UIWindow
    {
        [SerializeField] private Toggle musicMuter;
        [SerializeField] private Slider musicSlider;
        
        [SerializeField] private Toggle effectsMuter;
        [SerializeField] private Slider effectsSlider;

        [SerializeField] private Button backToMenu;

        
        [Inject]
        public void Construct(IUIService uiService, AudioService audioSevice)
        {
            backToMenu.onClick.AddListener(() => uiService.ReplaceWindow(WindowType.MainMenu));
            
            musicMuter.onValueChanged.AddListener(audioSevice.ToggleMusic);
            musicSlider.onValueChanged.AddListener(audioSevice.ChangeMusicVolume);
            
            effectsMuter.onValueChanged.AddListener(audioSevice.ToggleEffects);
            effectsSlider.onValueChanged.AddListener(audioSevice.ChangeEffectsVolume);
        }
    }
}