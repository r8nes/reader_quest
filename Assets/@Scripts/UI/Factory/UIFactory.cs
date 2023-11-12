using System.Collections.Generic;
using ChooseReader.Data.Static;
using ChooseReader.Service;
using ChooseReader.Service.Factory;
using ChooseReader.Service.Progress;
using ChooseReader.Structure.AssetManagment;
using ChooseReader.UI.Services;
using UnityEngine;

namespace ChooseReader.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT_PATH = "UI/UIRoot";

        private readonly IAssetProvider _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;

        private Transform _uiRoot;

        private List<WindowBase> _openWindows = new List<WindowBase>(3);

        public UIFactory(IAssetProvider asset, IStaticDataService staticData, IProgressService progressService)
        {
            _asset = asset;
            _staticData = staticData;
            _progressService = progressService;
        }

        public void CreateWindowById(WindowId windowId)
        {
            foreach (WindowBase openWindow in _openWindows)
            {
                WindowId id = openWindow.GetId();

                if (id == windowId) return;
                else
                {
                    Object.Destroy(openWindow);
                }
            }

            WindowConfig config = _staticData.LoadUIWindow(windowId);
            WindowBase window = Object.Instantiate(config.Prefab, _uiRoot);

            window.Construct(windowId, _progressService);
            window.WindowClosed += OnWindowClosed;

            _openWindows.Add(window);
        }

        public void CreateUIRoot(IGameFactory factory)
        {
            GameObject root = _asset.Instantiate(UI_ROOT_PATH);
            _uiRoot = root.transform;

            var mainRoot = root.GetComponent<MainRoot>();
            mainRoot.Construct(factory);
        }

        private void OnWindowClosed(WindowId id)
        {
            for (int i = 0; i < _openWindows.Count; i++)
            {
                if (_openWindows[i].GetId() == id)
                {
                    _openWindows[i].WindowClosed -= OnWindowClosed;
                    _openWindows.Remove(_openWindows[i]);
                }
            }
        }

        public Transform GetRootTransform()
        {
            return _uiRoot;
        }
    }
}