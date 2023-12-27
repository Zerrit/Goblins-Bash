using System.Collections.Generic;
using _1_Scripts.UIModules;
using _1_Scripts.UIWindows;
using UnityEngine;

namespace _1_Scripts.StaticData.UIModules
{
    [CreateAssetMenu(fileName = "AllUIModules", menuName = "Create All UIModules")]
    public class AllUIModulesData : ScriptableObject
    {
        [SerializeField] private GameObject rootUI;
        [SerializeField] private List<UIWindow> uiModules;

        public GameObject RootUI => rootUI;
        public IEnumerable<UIWindow> UIModules => uiModules;
    }
}