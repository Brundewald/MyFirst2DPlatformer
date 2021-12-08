using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using View;

namespace Controller
{
    public class RewardMenuHandler: IInitialize
    {
        private readonly RewardScreenView _rewardScreenView;
        private readonly RewardScreenModel _rewardScreenModel;
        private GameStateHandler _gameStateHandler;
        private TextMeshProUGUI _timerHolder;
        private bool _rewardWasTaken;
        private DateTime _whenRewardWasTaken;
        private bool _timerStopCounting;

        public event Action ShowScreenToPlayer = delegate() {  }; 
        public event Action ShowMessageToPlayer = delegate() {  }; 
        public RewardMenuHandler(ViewReferenceHolder view, ModelReferenceHolder models, GameStateHandler gameStateHandler)
        {
            _rewardScreenView = view.RewardScreenView;
            _rewardScreenModel = models.RewardScreenModel;
            _gameStateHandler = gameStateHandler;
            _timerHolder = _rewardScreenView.TimerHolder;
        }

        public void Initialize()
        {
            _rewardScreenView.Init(Back,GetReward);
            _timerHolder.text = $"{_rewardScreenModel.TimerMessage}";
        }

        private async void GetReward()
        {
            if (!_rewardWasTaken)
            {
                _rewardWasTaken = true;
                _whenRewardWasTaken = DateTime.UtcNow;
                ShowScreenToPlayer?.Invoke();
                await TimerLogic();
            }
            else
            {
                Debug.LogError("Invoke message");
                ShowMessageToPlayer?.Invoke();
            }
        }

            
        private async Task TimerLogic()
        {
            while (!_timerStopCounting)
            {
                var currentTime = DateTime.UtcNow;
                var time = (currentTime - _whenRewardWasTaken);

                var timeLeft = TimeSpan.FromSeconds(_rewardScreenModel.CoolDownTime) - time;

                _timerHolder.text =
                    $"{_rewardScreenModel.TimerMessage} {timeLeft.Hours:00}:{timeLeft.Minutes:00}:{timeLeft.Seconds:00}\n\r";

                _timerStopCounting = Math.Round(time.TotalSeconds) >= _rewardScreenModel.CoolDownTime;
                
                if (_timerStopCounting)
                {
                    Debug.LogError(_rewardWasTaken);
                    _rewardWasTaken = false;
                }
                await Task.Yield();
            }

            _timerStopCounting = false;
        }

        private void Back()
        {
            _gameStateHandler.OnGameStateChange(GameState.MainMenu);
        }
    }
}