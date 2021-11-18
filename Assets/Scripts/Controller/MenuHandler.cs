using UnityEngine;
using View;

namespace Controller
{
    public class MenuHandler:IInitialize
    {
        private readonly MainMenuView _mainMenuView;
        private readonly CharacterControlView _characterControlView;
        private GameStateHandler _gameStateHandler;

        public MenuHandler(MainMenuView mainMenuView, CharacterControlView characterControlView, GameStateHandler gameStateHandler)
        {
            _mainMenuView = mainMenuView;
            _mainMenuView.Init(Start, Exit);
            _characterControlView = characterControlView;
            _characterControlView.Init(Pause);
            
            _gameStateHandler = gameStateHandler;
        }

        private void Pause()
        {
            _gameStateHandler.OnGameStateChange(GameState.Pause);
        }

        private void Exit()
        {
            _gameStateHandler.OnGameStateChange(GameState.Exit);
        }

        private void Start()
        {
            _gameStateHandler.OnGameStateChange(GameState.Start);
        }

        public void Initialize()
        {
            
        }
    }
}