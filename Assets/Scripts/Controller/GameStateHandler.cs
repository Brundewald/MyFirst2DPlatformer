using System;
using UnityEngine;
using View;

namespace Controller
{
    public class GameStateHandler
    {
        private GameObject _mainMenu;
        private GameObject _gameScene;
        private GameObject _rewardMenu;
        public GameStateHandler(ObjectReferenceHolder objectReferenceHolder)
        {
            _mainMenu = objectReferenceHolder.MainMenu;
            _gameScene = objectReferenceHolder.LevelObject;
            _rewardMenu = objectReferenceHolder.RewardMenu;
        }

        public void OnGameStateChange(GameState state)
        {
            switch (state)
            {
                case GameState.MainMenu:
                    _gameScene.SetActive(false);
                    _rewardMenu.SetActive(false);
                    _mainMenu.SetActive(true);
                    break;

                case GameState.Start:
                    _mainMenu.SetActive(false);
                    _rewardMenu.SetActive(false);
                    _gameScene.SetActive(true);
                    break;
                
                case GameState.Reward:
                    _mainMenu.SetActive(false);
                    _gameScene.SetActive(false);
                    _rewardMenu.SetActive(true);
                    break;
                
                case GameState.Exit:
                    Application.Quit();
                    break;
            }
        }
    }
}