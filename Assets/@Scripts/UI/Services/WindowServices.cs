using ChooseReader.UI.Factory;

namespace ChooseReader.UI.Services
{
    public class WindowServices : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowServices(IUIFactory factory) 
        {
            _uiFactory = factory;
        }

        public void Open(WindowId WindowId) 
        {
            switch (WindowId)
            {
                case WindowId.SETTINGS:
                    break;
                case WindowId.LIBRARY:
                    break;
                case WindowId.CHAPTERS:
                    break;
                case WindowId.INFO:
                    break;
                case WindowId.ACHIVMENTS:
                    break;
                default:
                    break;
            }
        }
    }
}
