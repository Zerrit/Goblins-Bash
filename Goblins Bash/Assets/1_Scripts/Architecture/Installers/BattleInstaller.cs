using System;
using _1_Scripts.Enemies;
using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using _1_Scripts.UIWindows.Lose_Window;
using _1_Scripts.WeaponsLogic;
using UnityEditor;
using Zenject;

namespace _1_Scripts.Architecture
{
    public class BattleInstaller : MonoInstaller
    { 
        private ArtifactSystem _artifactSystem;
        private WavesController _wavesController;
        private PlayerController _playerController;

        
        
        public override void InstallBindings()
        {
            RegisterUIService();
            RegisterPlayerController();
            RegisterFactories();
            CreateMainBattleLogic();
            RegisterArtifactSystem();
            RegisterUpgradeSystem();
            RegisterLoseController();
            RegisterBattleProducer();
        }

        public override void Start()
        {
            
        }

        public void OnDestroy()
        {
        }


        private void RegisterUIService() // UI SERVICE
        {
            Container.Bind<UIFactory>().AsSingle();
            Container.Bind<IUIService>().To<UIService>().AsSingle();
        }

        private void RegisterPlayerController() // PLAYER CONTROLLER
        {
            Container.BindInterfacesTo<PlayerController>().AsSingle();
        }

        private void RegisterFactories() // FACTORIES
        {
            Container.Bind<WeaponsFactory>().AsSingle();
            Container.Bind<EnemiesFactory>().AsSingle();
        }
        
        private void CreateMainBattleLogic() // RUN PRODUCER
        {
            Container.Bind<EnemySpawner>().AsSingle();
            Container.Bind<IWavesController>().To<WavesController>().AsSingle();
            Container.Bind<ILevelsCreator>().To<LevelsCreator>().AsSingle();
        }
        
        private void RegisterArtifactSystem()  // ARTIFACT SYSTEM
        {
            Container.Bind<ArtifactSystem>().AsSingle();
        }

        private void RegisterUpgradeSystem()
        {
            Container.Bind<IUpgradeSystem>().To<UpgradeSystem>().AsSingle();
        }

        private void RegisterLoseController()
        {
            Container.Bind<ILoseWindowController>().To<LoseWindowController>().AsSingle();
        }
        
        private void RegisterBattleProducer() // BATTLE PRODUCER
        {
            Container.BindInterfacesTo<BattleProducer>().AsSingle();
        }
    }
}