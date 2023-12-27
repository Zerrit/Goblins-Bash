using _1_Scripts.Architecture.GameStates;
using _1_Scripts.Architecture.StateMachine;
using _1_Scripts.Logic;
using _1_Scripts.PlayerLogic;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using _1_Scripts.UIWindows.Lose_Window;
using Zenject;

namespace _1_Scripts.Architecture
{
    public class BattleProducer : ITickable, IInitializable
    {
        public IUIService UIService { get; }
        public ISceneLoader SceneLoader { get; }
        public EventsBus EventsBus { get; }
        public IWavesController WavesController { get; }
        public ILevelsCreator LevelsCreator { get; }
        public IPlayerController Player {get;}
        public IUpgradeSystem UpgradeSystem { get; }
        public ILoseWindowController LoseWindowController { get; }
        
        public GameStateMachine StateMachine { get;}
        public GameState PrepeareState { get;}
        public GameState BattleState { get;}
        public GameState LevelTransitionState { get;}
        public GameState PlayerUpgradeState { get;}
        public GameState LoseGameState { get;}
        
        //public int CurrentLevel { get; }


        public BattleProducer(ISceneLoader sceneLoader, IUIService uiService, EventsBus eventsBus, 
            IPlayerController player, IWavesController wavesController, ILevelsCreator levelsCreator, 
            IUpgradeSystem upgradeSystem, ILoseWindowController loseWindowController)
        {
            UIService = uiService;
            SceneLoader = sceneLoader;
            EventsBus = eventsBus;
            Player = player;
            WavesController = wavesController;
            LevelsCreator = levelsCreator;
            UpgradeSystem = upgradeSystem;
            LoseWindowController = loseWindowController;

            //CurrentLevel = 1;
            
            StateMachine = new GameStateMachine();
            
            PrepeareState = new PrepeareState(this);
            BattleState = new BattleState(this);
            LevelTransitionState = new LevelTransitionState(this);
            PlayerUpgradeState = new PlayerUpgradeState(this);
            LoseGameState = new LoseGameState(this);
        }

        public void Initialize()
        {
            StateMachine.Initialize(PrepeareState);
        }
        
        public void Tick()
        {
            StateMachine.CurrentGameState?.Update();
        }
    }
}