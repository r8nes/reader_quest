using ChooseReader.Service.Factory;
using UnityEngine;


namespace ChooseReader.UI
{
    public class MainRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _hud;

        private IGameFactory _factory;

        public void Construct(IGameFactory factory)
        {
            _factory = factory;

            AddButtons();
        }

        public void AddButtons() => _factory.AddWindowsSettings(_hud);
    }
}