using ChooseReader.Service;

namespace ChooseReader.UI.Services
{
    public interface IWindowService : IService
    {
        public void Open(WindowId WindowId);
    }
}