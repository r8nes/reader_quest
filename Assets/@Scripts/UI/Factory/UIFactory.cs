using System.Threading.Tasks;
using ChooseReader.Data.Static;
using ChooseReader.Service;
using ChooseReader.Service.Progress;
using ChooseReader.Structure.AssetManagment;
using ChooseReader.UI.Services;
using UnityEngine;

namespace ChooseReader.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT_PATH = "UI/UIRoot";

        private readonly IAsset _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;

        private Transform _uiRoot;

        public UIFactory(IAsset asset, IStaticDataService staticData, IProgressService progressService)
        {
            _asset = asset;
            _staticData = staticData;
            _progressService = progressService;
        }

        public void CreateShop()
        {
            WindowConfig config = _staticData.LoadUIWindow(WindowId.ACHIVMENTS);
            WindowBase window = Object.Instantiate(config.Prefab, _uiRoot);

            window.Construct(_progressService);
        }

        public async Task CreateUIRoot()
        {
            GameObject root = await _asset.Instantiate(UI_ROOT_PATH);
            _uiRoot = root.transform;
        }
    }
}