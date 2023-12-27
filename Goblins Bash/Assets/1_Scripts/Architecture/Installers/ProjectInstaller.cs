using System;
using _1_Scripts.Audio;
using _1_Scripts.GameProgress;
using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.StaticData;
using _1_Scripts.UIModules;
using UnityEngine;
using Zenject;

namespace _1_Scripts.Architecture
{
    public class ProjectInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private AudioService audioService;

        private IDataProvider _dataProvider;
        private IPersistentData _persistentData;
        private ISpendable _spendableService;
        private IRewardable _rewardableService;
        private ProgressService _progressService;
        private IStaticDataService _staticDataService;
        
        private ISceneLoader _sceneLoader;
        private EventsBus _eventsBus;

        public override void InstallBindings()
        {
            RegisterCoroutineRunner();
            RegisterDataProviderService();
            RegisterEventsBus();
            RegisterWalletService();
            RegisterProgressService();
            RegisterStaticDataService();
            
            RegisterSceneLoader();
            RegisterAudioService();
        }
        
        private void RegisterCoroutineRunner() => Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();

        private void RegisterDataProviderService()
        {
            _persistentData = new PersistentData();
            _dataProvider = new LocalDataProvider(_persistentData);
            LoadDataOrInit();
            
            Container.Bind<IPersistentData>().FromInstance(_persistentData).AsSingle();
            Container.Bind<IDataProvider>().FromInstance(_dataProvider).AsSingle();
        }
        
        private void LoadDataOrInit()
        {
            if (_dataProvider.TryLoad()) Debug.Log("Данные загружены");
            else _persistentData.Progress = new PlayerProgress();
        }
        
        private void RegisterEventsBus()
        {
            _eventsBus = new EventsBus();
            Container.Bind<EventsBus>().AsSingle();
        }
        
        private void RegisterWalletService()
        {
            WalletService walletService = Container.Instantiate<WalletService>();
            Container.Bind<ISpendable>().FromInstance(walletService).AsSingle();
            Container.Bind<IRewardable>().FromInstance(walletService).AsSingle();
        }

        private void RegisterProgressService()
        {
            _progressService = Container.Instantiate<ProgressService>();
            Container.Bind<ProgressService>().FromInstance(_progressService).AsSingle();
        }
        
        private void RegisterStaticDataService()
        {
            _staticDataService = new StaticDataService();
            Container.Bind<IStaticDataService>().FromInstance(_staticDataService).AsSingle();
        }

        private void RegisterSceneLoader()
        {
            _sceneLoader = Container.Instantiate<SceneLoader>();
            Container.Bind<ISceneLoader>().FromInstance(_sceneLoader).AsSingle();
        }

        private void RegisterAudioService()
        {
            Container.InstantiatePrefabForComponent<AudioService>(audioService);
            Container.Bind<AudioService>().FromInstance(audioService);
        }
    }
}
