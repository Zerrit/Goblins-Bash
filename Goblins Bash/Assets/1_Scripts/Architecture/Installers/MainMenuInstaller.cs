using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using Zenject;

namespace _1_Scripts.Architecture
{
    public class MainMenuInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            
            RegisterUIService();
            RegisterMainMenuProducer();
        }


////////////------------------////////////////////

        private void RegisterUIService()
        {
            Container.Bind<UIFactory>().AsSingle();
            Container.Bind<IUIService>().To<UIService>().AsSingle();
        }

        private void RegisterMainMenuProducer()
        {
            Container.Bind<IInitializable>()
                .To<MainMenuProducer>()
                .AsSingle();
        }
    }
}