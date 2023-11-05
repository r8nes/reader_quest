using ChooseReader.Logic;
using UnityEngine;

namespace ChooseReader.Structure
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        public LoadingUI LoadingUIPref;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(LoadingUIPref));
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}

