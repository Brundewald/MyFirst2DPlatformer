using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace View
{
    public class MainMenuView : MonoBehaviour
    {
        [Header("Buttons view")] 
        [Tooltip("Drag&drop start button view")] [SerializeField]
        private Button _startButton;

        [Tooltip("Drag&drop reward screen button here")][SerializeField]
        private Button _rewardScreenButton;
        
        [Tooltip("Drag&drop exit button view")] [SerializeField]
        private Button _exitButton;

        public void Init(UnityAction startGame, UnityAction exitGame, UnityAction goToRewardScreen)
        {
            _startButton.onClick.AddListener(startGame);
            _rewardScreenButton.onClick.AddListener(goToRewardScreen);
            _exitButton.onClick.AddListener(exitGame);
        }

        public void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
            _rewardScreenButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}