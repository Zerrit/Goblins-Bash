using _1_Scripts.StaticData;
using _1_Scripts.UIModules;
using UnityEngine;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class UIFactory
    {
        private readonly DiContainer _diContainer;
        private readonly IStaticDataService _staticDataService;


        public UIFactory(IStaticDataService staticDataService, DiContainer diContainer)
        {
            _diContainer = diContainer;
            _staticDataService = staticDataService;
        }

        public UIWindow GetModule(WindowType windowType, ref Transform parentPoint)
        {
            if (parentPoint == null) parentPoint = _diContainer.InstantiatePrefab(_staticDataService.RootUI).transform;
            UIWindow window = _staticDataService.GetDataFor(windowType);
            if (!window) throw new System.Exception("Не удалось получить статические данные для следующего модуля "+ windowType);
            return _diContainer.InstantiatePrefabForComponent<UIWindow>(window, parentPoint);
        }
    }
}