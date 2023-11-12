using System;
using System.Collections.Generic;
using ChooseReader.Logic;
using ChooseReader.Service;
using ChooseReader.Service.Factory;
using ChooseReader.Service.Progress;
using ChooseReader.UI.Factory;
using UnityEngine;

namespace ChooseReader.Structure
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingUI loadingUi, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(
                this,
                sceneLoader,
                services),
                [typeof(LoadLevelState)] = new LoadLevelState(
                this,
                sceneLoader,
                loadingUi,
                services.Single<IProgressService>(),
                services.Single<IStaticDataService>(),
                services.Single<IGameFactory>(),
                services.Single<IUIFactory>()),
                [typeof(LoadProgressState)] = new LoadProgressState(
                this,
                services.Single<IProgressService>(),
                services.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            Debug.Log(state.GetType().Name.ToString());

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;
    }
}
