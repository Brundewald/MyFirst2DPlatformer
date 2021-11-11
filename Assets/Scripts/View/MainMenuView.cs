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
        
        [Tooltip("Drag&drop exit button view")] [SerializeField]
        private Button _exitButton;

        public void Init(UnityAction startGame, UnityAction exitGame)
        {
            _startButton.onClick.AddListener(startGame);
            _exitButton.onClick.AddListener(exitGame);
        }

        public void OnDestroy()
        {
            _startButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}