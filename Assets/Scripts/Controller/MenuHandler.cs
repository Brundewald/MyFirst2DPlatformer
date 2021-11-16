﻿using UnityEngine;
using View;

namespace Controller
{
    public class MenuHandler:IInitialize
    {
        private MainMenuView _mainMenuView;
        private GameStateHandler _gameStateHandler;
        public MenuHandler(MainMenuView mainMenuView, GameStateHandler gameStateHandler)
        {
            _mainMenuView = mainMenuView;
            _mainMenuView.Init(StartMessage, ExitMessage);
            _gameStateHandler = gameStateHandler;
        }

        private void ExitMessage()
        {
            _gameStateHandler.OnGameStateChange(GameState.Exit);
        }

        private void StartMessage()
        {
            _gameStateHandler.OnGameStateChange(GameState.Start);
        }

        public void Initialize()
        {
            
        }
    }
}