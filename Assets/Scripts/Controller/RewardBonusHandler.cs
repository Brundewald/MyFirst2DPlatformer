using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Controller
{
    public class RewardBonusHandler : IInitialize, ICleanup
    {
        private readonly RewardMenuHandler _rewardMenuHandler;
        private GameObject _bonusScreenPrefab;
        private GameObject _bonusScreen;
        private TextMeshProUGUI _textWindow;

        public RewardBonusHandler(GameObject bonusScreenPrefab, RewardMenuHandler rewardMenuHandler)
        {
            _bonusScreenPrefab = bonusScreenPrefab;
            _rewardMenuHandler = rewardMenuHandler;

        }

        public void Initialize()
        {
            _rewardMenuHandler.ShowScreenToPlayer += ShowBonusScreenAsync;
        }

        public void Cleanup()
        {
            _rewardMenuHandler.ShowScreenToPlayer -= ShowBonusScreenAsync;
        }

        private async void ShowBonusScreenAsync()
        {
            _bonusScreen = Object.Instantiate(_bonusScreenPrefab);
            await Task.Delay(2000);
            if (_bonusScreen != null)
                Object.Destroy(_bonusScreen);
            else
                return;
        }
    }
}