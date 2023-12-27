using _1_Scripts.Architecture;
using _1_Scripts.UIModules;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class MainMenuWindow : UIWindow
    {
        [SerializeField] private Button playBtn;
        [SerializeField] private Button artifactShop;
        [SerializeField] private Button weaponShop;
        [SerializeField] private Button settings;


        [Inject]
        public void Construct(IUIService uiService, EventsBus eventsBus, ISceneLoader sceneLoader)
        {
            artifactShop.onClick.AddListener(() => uiService.ShowWindow(WindowType.ArtifactShop));
            weaponShop.onClick.AddListener(() => uiService.ShowWindow(WindowType.WeaponShop));
            settings.onClick.AddListener(() => uiService.ShowWindow(WindowType.Settings));
            
            playBtn.onClick.AddListener(sceneLoader.LoadScene);
        }
    }
}