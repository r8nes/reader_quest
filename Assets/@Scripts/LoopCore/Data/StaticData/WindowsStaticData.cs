using System.Collections.Generic;
using UnityEngine;

namespace ChooseReader.Data.Static
{
    [CreateAssetMenu(fileName = "WindowData", menuName = "StaticData/Window")]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs; 
    }
}
