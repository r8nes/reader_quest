using System.Collections.Generic;
using ChooseReader.Service.Progress;
using UnityEngine;

namespace ChooseReader.Service.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgress> ProgressWriters { get; }
        List<ISavedProgressReader> ProgressReader { get; }
        void AddWindowsSettings(GameObject hud);
        void Cleanup();
    }
}
