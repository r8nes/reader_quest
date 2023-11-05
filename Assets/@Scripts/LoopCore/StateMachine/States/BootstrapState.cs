using ChooseReader.Data.Static;
using ChooseReader.Service;
using ChooseReader.Service.Progress;
using ChooseReader.Service.Randomizer;
using ChooseReader.Structure.AssetManagment;

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

        private void RegisterService()
        {
            RegisterStaticData();

            _services.RegisterSingle<IGameStateMachine>(_stateMachine);

            RegisterAssetProvider();

            _services.RegisterSingle<IProgressService>(new ProgressService());
            _services.RegisterSingle<IRandomService>(new RandomService());

            _services.RegisterSingle<ISaveLoadService>(
                new SaveLoadService(_services.Single<IProgressService>()));
        }

        private void RegisterAssetProvider()
        {
            var assetProvider = new AssetProvider();

            assetProvider.Initialize();
            _services.RegisterSingle<IAsset>(assetProvider);
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();

            _services.RegisterSingle(staticData);
        }

        public void Enter() => _sceneLoader.Load(INITIAL_SCENE, onLoaded: EnterLoadLevel);
        private void EnterLoadLevel() => _stateMachine.Enter<LoadProgressState>();
        public void Exit() {}
    }
}
