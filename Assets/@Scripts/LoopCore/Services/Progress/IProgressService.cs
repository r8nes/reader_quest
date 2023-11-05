using ChooseReader.Data;

namespace ChooseReader.Service.Progress
{
    public interface IProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}