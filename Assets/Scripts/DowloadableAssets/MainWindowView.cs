using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DowloadableAssets
{
    public class MainWindowView: AssetBundleViewBase
    {
        [SerializeField] private Button _loadAssetButton;


        private void Start()
        {
            _loadAssetButton.onClick.AddListener(LoadAssetsAsync);
        }

        private void OnDestroy()
        {
            _loadAssetButton.onClick.RemoveAllListeners();
        }

        private void LoadAssetsAsync()
        {
            _loadAssetButton.interactable = false;
            Debug.Log(Thread.CurrentThread.ManagedThreadId);
            DownloadAndSetAssetBundleAsync();
        }
    }
}