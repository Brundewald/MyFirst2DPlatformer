using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    public class RewardWasReceivedMessageHandler:IInitialize, ICleanup
    {
        private readonly GameObject _messagePrefab;
        private readonly RewardMenuHandler _rewardMenuHandler;
        private GameObject _messageInstance;
        
        public RewardWasReceivedMessageHandler(GameObject messagePrefab, RewardMenuHandler rewardMenuHandler)
        {
            _messagePrefab = messagePrefab;
            _rewardMenuHandler = rewardMenuHandler;
        }

        public void Initialize()
        {
            _rewardMenuHandler.ShowMessageToPlayer += ShowBonusScreenAsync;
        }

        public void Cleanup()
        {
            _rewardMenuHandler.ShowMessageToPlayer -= ShowBonusScreenAsync;
        }
        
        private async void ShowBonusScreenAsync()
        {
            if (_messageInstance == null)
            {
                _messageInstance = Object.Instantiate(_messagePrefab);
                await Task.Delay(2000);
                if (_messageInstance != null)
                    Object.Destroy(_messageInstance);
            }
            else 
            { 
                await Task.Delay(2000);
                Object.Destroy(_messageInstance);
            }
        }
    }
}