using System.Collections.Generic;
using ChooseReader.Service.Progress;
using ChooseReader.Service.Randomizer;
using ChooseReader.Structure.AssetManagment;
using ChooseReader.UI;
using ChooseReader.UI.Services;
using UnityEngine;

namespace ChooseReader.Service.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IRandomService _random;
        private readonly IAssetProvider _assets;
        private readonly IWindowService _windowService;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;


        public GameFactory(IAssetProvider assets, IStaticDataService staticData, IRandomService random, IProgressService progressService, IWindowService windowService)
        {
            _assets = assets;
            _random = random;
            _staticData = staticData;
            _windowService = windowService;
            _progressService = progressService;
        }

        public void Cleanup()
        {
            ProgressReader.Clear();
            ProgressWriters.Clear();
        }

        #region CreateMethods

        public void AddWindowsSettings(GameObject hud)
        {
            foreach (OpenWindowButton window in hud.GetComponentsInChildren<OpenWindowButton>())
                window.Construct(_windowService);
        }

        #endregion

        /* Регистрация объектов сейчас пустует, ибо сохранять данные пока не нужно.
            Но я добавил этот сервис в прототип, если захочу с ним сделать что-то в дальнейшем */

        #region NoUsed

        public void Register(ISavedProgressReader reader)
        {
            if (reader is ISavedProgress writer)
                ProgressWriters.Add(writer);

            ProgressReader.Add(reader);
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponents<ISavedProgressReader>())
                Register(progressReader);
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector2 parent)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, parent);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        public List<ISavedProgressReader> ProgressReader => new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters => new List<ISavedProgress>();

        #endregion
    }
}
