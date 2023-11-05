using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ChooseReader.Structure.AssetManagment
{
    public class AssetProvider : IAsset
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCashe = new Dictionary<string, AsyncOperationHandle>();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();

        public void Initialize() => Addressables.InitializeAsync();

        public Task<GameObject> Instantiate(string address, Vector3 at) =>
        Addressables.InstantiateAsync(address, at, Quaternion.identity).Task;

        public Task<GameObject> Instantiate(string address) =>
          Addressables.InstantiateAsync(address).Task;

        public async Task<T> Load<T>(string address) where T : class
        {
            if (_completedCashe.TryGetValue(address, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunCashOnComplete(
                         Addressables.LoadAssetAsync<T>(address),
                          casheKey: address);
        }

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completedCashe.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
                return completedHandle.Result as T;

            return await RunCashOnComplete(
                Addressables.LoadAssetAsync<T>(assetReference),
                casheKey: assetReference.AssetGUID);
        }

        public void CleanUp()
        {
            foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
                foreach (AsyncOperationHandle handle in resourceHandles)
                    Addressables.Release(handle);

            _completedCashe.Clear();
            _handles.Clear();
        }

        private async Task<T> RunCashOnComplete<T>(AsyncOperationHandle<T> handle, string casheKey) where T : class
        {
            handle.Completed += completeHandle =>
            {
                _completedCashe[casheKey] = completeHandle;
            };

            AddHandle(casheKey, handle);
            return await handle.Task;
        }

        private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
        {
            if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[key] = resourceHandles;
            }

            resourceHandles.Add(handle);
        }
    }
}
