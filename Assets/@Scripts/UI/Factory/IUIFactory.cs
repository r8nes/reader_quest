using ChooseReader.Service;
using ChooseReader.Service.Factory;
using ChooseReader.UI.Services;
using UnityEngine;

namespace ChooseReader.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateWindowById(WindowId windowId);
        void CreateUIRoot(IGameFactory factory);
        Transform GetRootTransform();
    }
}
