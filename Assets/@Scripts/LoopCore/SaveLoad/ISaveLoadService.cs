using ChooseReader.Data;
using ChooseReader.Service;

namespace ChooseReader.Structure
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();

        void PrintPlayerPrefs();
    }
}
