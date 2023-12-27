using _1_Scripts.Architecture.GameStates;
using _1_Scripts.StaticData;
using _1_Scripts.UIModules;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace _1_Scripts.Architecture
{
    public class SceneLoader : ISceneLoader
    {
        private readonly IStaticDataService _staticDataService;
        private LoadScreen _loadScreen;

        
        public SceneLoader(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        
        public void LoadScene()
        {
            if(_loadScreen == null) CreateLoadScreen();
            
            _loadScreen.Show();
            AsyncOperation sceneWaiter = SceneManager.LoadSceneAsync(GetRingtSceneName());
            sceneWaiter.completed += _ =>
            {
                _loadScreen.Hide();
            };
        }

        private string GetRingtSceneName()
        {
            return (SceneManager.GetActiveScene().buildIndex == 0)
                ? "Battle"
                : "Menu";
        }
        
        private void CreateLoadScreen()
        {
            _loadScreen = Object.Instantiate(_staticDataService.LoadScreen);
            Object.DontDestroyOnLoad(_loadScreen);
        }
    }

    public interface ISceneLoader
    {
        public void LoadScene();
    }
}