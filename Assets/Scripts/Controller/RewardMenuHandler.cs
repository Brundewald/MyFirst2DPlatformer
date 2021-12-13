using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using View;

namespace Controller
{
    public class RewardMenuHandler: IInitialize, ICleanup
    {
        private readonly RewardScreenView _rewardScreenView;
        private readonly RewardScreenModel _rewardScreenModel;
        private readonly GameStateHandler _gameStateHandler;
        private readonly TextMeshProUGUI _timerHolder;
        private DataSaveHandler _dataSaveHandler;
        
        public event Action ShowScreenToPlayer = delegate() {  }; 
        public event Action ShowMessageToPlayer = delegate() {  }; 
        public RewardMenuHandler(ViewReferenceHolder view, ModelReferenceHolder models, GameStateHandler gameStateHandler)
        {
            _rewardScreenView = view.RewardScreenView;
            _rewardScreenModel = models.RewardScreenModel;
            _gameStateHandler = gameStateHandler;
            _timerHolder = _rewardScreenView.TimerHolder;
            _dataSaveHandler = new DataSaveHandler(models.RewardScreenModel);
        }

        public async void Initialize()
        {
            _rewardScreenView.Init(Back,GetReward);
            
            var loadedData = _dataSaveHandler.LoadRewardData();
            _rewardScreenModel.RewardWasTaken = loadedData.RewardWasTaken;
            _rewardScreenModel.WhenRewardWasTaken = TimeSpan.Parse(loadedData.DateTimeWhenRewardWasTaken);
            
            if (_rewardScreenModel.RewardWasTaken)
            {
                await TimerLogic();
            }
            else
                _timerHolder.text = $"{_rewardScreenModel.TimerMessage}";
        }

        public void Cleanup()
        {
            _dataSaveHandler.SaveRewardData();
        }

        private async void GetReward()
        {
            if (!_rewardScreenModel.RewardWasTaken)
            {
                _rewardScreenModel.RewardWasTaken = true;
                _rewardScreenModel.WhenRewardWasTaken = DateTime.UtcNow.TimeOfDay;
                ShowScreenToPlayer?.Invoke();
                await TimerLogic();
            }
            else
            {
                ShowMessageToPlayer?.Invoke();
            }
        }


        private async Task TimerLogic()
        {
            while (_rewardScreenModel.RewardWasTaken)
            {
                var currentTime = DateTime.UtcNow.TimeOfDay;
                Debug.LogError(_rewardScreenModel.WhenRewardWasTaken + "\n\r" + currentTime);
                var time = currentTime - _rewardScreenModel.WhenRewardWasTaken;
                var timeLeft = TimeSpan.FromSeconds(_rewardScreenModel.CoolDownTime) - time;
                
                _timerHolder.text =
                    $"{_rewardScreenModel.TimerMessage} {timeLeft.Hours:00}:{timeLeft.Minutes:00}:{timeLeft.Seconds:00}\n\r";

                var timerStopCounting = Math.Round(time.TotalSeconds) >= _rewardScreenModel.CoolDownTime;
                
                if (timerStopCounting)
                {
                    Debug.LogError(_rewardScreenModel.RewardWasTaken);
                    _rewardScreenModel.RewardWasTaken = false;
                }
                await Task.Yield();
            }
        }

        private void Back()
        {
            _gameStateHandler.OnGameStateChange(GameState.MainMenu);
        }
    }
}