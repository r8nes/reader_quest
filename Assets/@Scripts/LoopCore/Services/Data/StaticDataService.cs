using System.Collections.Generic;
using System.Linq;
using ChooseReader.Service;
using ChooseReader.UI.Services;
using UnityEngine;

namespace ChooseReader.Data.Static
{
    public class StaticDataService : IStaticDataService
    {
        private const string LEVELS_PATH = "Data/ReaderData";
        private const string WINDOWS_PATH = "Data/Windows/WindowData";

        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void Load()
        {
            _levels = Resources.LoadAll<LevelStaticData>(LEVELS_PATH).ToDictionary(x => x.BookKey, x => x);
            _windowConfigs = Resources.Load<WindowsStaticData>(WINDOWS_PATH).Configs.ToDictionary(x => x.WindowId, x => x);
        }

        public LevelStaticData LoadReaderData(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData data)
            ? data
            : null;

        public WindowConfig LoadUIWindow(WindowId windowId) => 
            _windowConfigs.TryGetValue(windowId, out WindowConfig data)
          ? data
          : null;
    }
}
