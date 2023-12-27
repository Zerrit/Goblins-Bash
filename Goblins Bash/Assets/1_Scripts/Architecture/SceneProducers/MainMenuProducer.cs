using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using Zenject;

namespace _1_Scripts.Architecture
{
    public class MainMenuProducer : IInitializable
    {
        private readonly IUIService _uiService;
        
        public MainMenuProducer(IUIService uiService)
        {
            _uiService = uiService;
        }
        
        
        public void Initialize()
        {
            _uiService.ShowWindow(WindowType.MainMenu);
        }
    }
}