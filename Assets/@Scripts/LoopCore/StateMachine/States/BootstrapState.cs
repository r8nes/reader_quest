using ChooseReader.Data.Static;
using ChooseReader.Service;
using ChooseReader.Service.Factory;
using ChooseReader.Service.Progress;
using ChooseReader.Service.Randomizer;
using ChooseReader.Structure.AssetManagment;
using ChooseReader.UI.Factory;
using ChooseReader.UI.Services;

namespace ChooseReader.Structure
{
    public class BootstrapState : IState
    {
        private const string INITIAL_SCENE = "Initial";

        private readonly AllServices _services;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterService();
        }

        #region Services
        private void RegisterService()
        {
            RegisterStateMachine();
            RegisterAssetProvider();
            RegisterStaticData();
            RegisterProgressService();
            RegisterRandomService();
            RegisterUIFactory();
            RegisterWindowService();
            RegisterGameFactory();
            RegisterSaveLoadService();
        }

        private void RegisterStateMachine()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
        }

        private void RegisterUIFactory()
        {
            _services.RegisterSingle<IUIFactory>(
                new UIFactory(
                _services.Single<IAssetProvider>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IProgressService>()));
        }

        private void RegisterGameFactory()
        {
            _services.RegisterSingle<IGameFactory>(
                            new GameFactory(
                            _services.Single<IAssetProvider>(),
                            _services.Single<IStaticDataService>(),
                            _services.Single<IRandomService>(),
                            _services.Single<IProgressService>(),
                            _services.Single<IWindowService>()));
        }

        private void RegisterSaveLoadSevice()
        {
            _services.RegisterSingle<ISaveLoadService>(
                new SaveLoadService(_services.Single<IProgressService>()));
        }


        private void RegisterWindowService()
        {
            _services.RegisterSingle<IWindowService>(
               new WindowServices(
            _services.Single<IUIFactory>()
            ));
        }

        private void RegisterRandomService()
        {
            _services.RegisterSingle<IRandomService>(new RandomService());
        }

        private void RegisterProgressService()
        {
            _services.RegisterSingle<IProgressService>(new ProgressService());
        }

        private void RegisterAssetProvider()
        {
            var assetProvider = new AssetProvider();
            _services.RegisterSingle<IAssetProvider>(assetProvider);
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();

            _services.RegisterSingle(staticData);
        }

        private void RegisterSaveLoadService()
        {
            _services.RegisterSingle<ISaveLoadService>(
                new SaveLoadService(_services.Single<IProgressService>()));
        }

        #endregion

        public void Enter() => _sceneLoader.Load(INITIAL_SCENE, onLoaded: EnterLoadLevel);
        private void EnterLoadLevel() => _stateMachine.Enter<LoadProgressState>();
        public void Exit() { }
    }
}
