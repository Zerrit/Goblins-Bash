using System.Collections.Generic;
using _1_Scripts.UIModules;
using UnityEngine;
using UnityEngine.UI;

namespace _1_Scripts.UIWindows
{
    public class UIService : IUIService
    {
        public IReadOnlyDictionary<WindowType, UIWindow> UIModules => _modulesByTypes;

        private readonly UIFactory _uiFactory;
        private readonly Dictionary<WindowType, UIWindow> _modulesByTypes = new ();

        private UIWindow _currentWindow;
        private Transform _parentCanvas;
        
        
        public UIService(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }


        public void RegisterModule(UIWindow window)
        {
            if (_modulesByTypes.ContainsKey(window.Type)) _modulesByTypes[window.Type] = window;
            else _modulesByTypes.Add(window.Type, window);
        }
        
        
        public void ShowWindow(WindowType type)
        {
            UIWindow window;
            if (_modulesByTypes.ContainsKey(type)) _modulesByTypes.TryGetValue(type, out window);
            else CreateModule(type, out window);
            
            _currentWindow = window;
            if(window) window.Show();
        }

        public void HideWindow(WindowType type)
        {
            if (!_modulesByTypes.ContainsKey(type)) return;
            _modulesByTypes.TryGetValue(type, out UIWindow module);
            
            if(module) module.Hide();
        }
        
        
        
        public void ReplaceWindow(WindowType type)
        {
            UIWindow window;
            if (_modulesByTypes.ContainsKey(type)) _modulesByTypes.TryGetValue(type, out window);
            else CreateModule(type, out window);

            if(_currentWindow) _currentWindow.Hide();
            _currentWindow = window;
            if(window) window.Show();
        }


        private void CreateModule(WindowType type, out UIWindow window)
        {
            window = _uiFactory.GetModule(type, ref _parentCanvas);
            RegisterModule(window);
        }
    }
}


