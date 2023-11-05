using ChooseReader.Data.Static;
using ChooseReader.UI.Services;

namespace ChooseReader.Service
{
    public interface IStaticDataService : IService
    {
        LevelStaticData LoadReaderData(string sceneKey);
        WindowConfig LoadUIWindow(WindowId windowId);

        void Load();
    }
}