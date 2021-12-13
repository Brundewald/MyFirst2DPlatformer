using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Assets.Scripts.DowloadableAssets
{
    public class MainWindowView: AssetBundleViewBase
    {
        [SerializeField] private Button _loadAssetButton;
        [SerializeField] private AssetReference _loadPrefab;
        [SerializeField] private RectTransform _mountSpawnTransform;
        private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new List<AsyncOperationHandle<GameObject>>();


        private void Start()
        {
            _loadAssetButton.onClick.AddListener(LoadAssetsAndSpawn);
        }

        private void OnDestroy()
        {
            _loadAssetButton.onClick.RemoveAllListeners();
            foreach (var addressablePrefab in _addressablePrefabs)
            {
                Addressables.ReleaseInstance(addressablePrefab);
            }
            _addressablePrefabs.Clear();
        }

        private void LoadAssetsAndSpawn()
        {
            _loadAssetButton.interactable = false;
            Debug.Log(Thread.CurrentThread.ManagedThreadId);
            DownloadAndSetAssetBundleAsync();
            var addressablePrefab = Addressables.InstantiateAsync(_loadPrefab, _mountSpawnTransform);
            _addressablePrefabs.Add(addressablePrefab);
        }
    }
}