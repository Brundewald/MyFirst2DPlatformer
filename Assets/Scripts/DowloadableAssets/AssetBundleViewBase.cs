using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.DowloadableAssets
{
    public class AssetBundleViewBase: MonoBehaviour
    {
        private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1ok1AXqQDdM5c3SJ17zK-1V86Z0mZD5QL";
        private const string UrlAssetBundleAudio = "";

        [SerializeField] private DataSpriteBundle[] _dataSpriteBundle;
        [SerializeField] private DataAudioBundle[] _dataAudioBundle;

        private AssetBundle _spriteAssetBundle;
        private AssetBundle _audioAssetBundle;

        protected async void DownloadAndSetAssetBundleAsync()
        {
            await Task.Factory.StartNew(GetSpritesAssetBundleAsync);
            await Task.WhenAll(GetSpritesAssetBundleAsync());
            if (_spriteAssetBundle == null)
            {
                Debug.LogError("Didn't get asset bundle");
            }
            SetDownloadAsset();
        }

        private async Task GetSpritesAssetBundleAsync()
        {
            Debug.Log(Thread.CurrentThread.ManagedThreadId);
            var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);
            request.SendWebRequest();
            while (!request.isDone)
            {
                await Task.Yield();
            }

            StateRequest(request, ref _spriteAssetBundle);
        }

        private void SetDownloadAsset()
        {
            foreach (var data in _dataSpriteBundle)
            {
                data.Image.sprite = _spriteAssetBundle.LoadAsset<Sprite>(data.ImageID);
            }
        }

        private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("Complete!");
            }
            else
            {
                Debug.LogError(request.error);
            }
        }
    }
}