using System;
using ChooseReader.UI;
using ChooseReader.UI.Services;

namespace ChooseReader.Data.Static
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}