using ChooseReader.Data.Static;
using ChooseReader.Logic;
using ChooseReader.Service;
using ChooseReader.Service.Factory;
using ChooseReader.Service.Progress;
using ChooseReader.UI.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChooseReader.Structure
{
    public class LoadLevelState : IPayLoadState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingUI _loadingUI;

        private readonly IProgressService _service;
        private readonly IStaticDataService _staticData;
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingUI loadingUI, IProgressService service, IStaticDataService staticData, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingUI = loadingUI;
            _service = service;
            _staticData = staticData;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }


        public void Enter(string sceneName)
        {
            _loadingUI.ShowLoader();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() => _loadingUI.HideLoader();

        private void OnLoaded()
        {
            InitUIRoot();
            
            _gameStateMachine.Enter<GameLoopState>();
        }
        private void InitUIRoot() => _uiFactory.CreateUIRoot(_gameFactory);

        private LevelStaticData GetLevelStaticData()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.LoadReaderData(sceneKey);

            return levelData;
        }
    }
}
