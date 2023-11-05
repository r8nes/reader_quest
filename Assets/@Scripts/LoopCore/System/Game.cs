using ChooseReader.Logic;
using ChooseReader.Service;

namespace ChooseReader.Structure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingUI loadingUi)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingUi, AllServices.Container);
        }
    }
}