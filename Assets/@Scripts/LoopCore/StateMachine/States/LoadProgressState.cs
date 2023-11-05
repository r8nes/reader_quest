using ChooseReader.Data;
using ChooseReader.Service.Progress;

namespace ChooseReader.Structure
{
    public class LoadProgressState : IState
    {
        private const string START_SCENE = "Main";

        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
           // _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew() =>
            _progressService.Progress =
            _saveLoadService.LoadProgress()
            ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();

            progress.Data.Books = 0;
            progress.Data.Chapters = 0;
            progress.Data.Fame = 0;
            progress.Data.Name = "Noname";
            progress.Data.IsPremium = false;

            return progress;
        }
    }
}
