using System.Threading.Tasks;
using ChooseReader.Service;

namespace ChooseReader.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateShop();
        Task CreateUIRoot();
    }
}
