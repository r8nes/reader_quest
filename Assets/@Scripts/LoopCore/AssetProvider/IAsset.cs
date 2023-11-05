using System.Threading.Tasks;
using ChooseReader.Service;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ChooseReader.Structure.AssetManagment
{
    public interface IAsset : IService
    {
        void CleanUp();

        public void Initialize();

        public Task<GameObject> Instantiate(string address, Vector3 at);
        public Task<GameObject> Instantiate(string address);

        Task<T> Load<T>(string address) where T : class;
        Task<T> Load<T>(AssetReference adressReference) where T : class;
    }
}