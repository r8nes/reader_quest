﻿namespace ChooseReader.Structure
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IExitableState 
    {
        void Exit();
    }

    public interface IPayLoadState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}
