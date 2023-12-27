using System.Collections.Generic;
using _1_Scripts.UIModules;

namespace _1_Scripts.UIWindows
{
    public interface IUIService
    {
        public IReadOnlyDictionary<WindowType, UIWindow> UIModules { get; }

        public void RegisterModule(UIWindow window);
        public void ShowWindow(WindowType type);
        public void HideWindow(WindowType type);
        public void ReplaceWindow(WindowType type);
    }
}