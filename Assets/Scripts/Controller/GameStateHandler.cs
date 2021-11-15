using UnityEngine;

namespace Controller
{
    public class GameStateHandler
    {
        private GameObject _mainMenu;
        private GameObject _gameScene;
        private EndGameHandler _endGame;
        public GameStateHandler(GameObject mainMenu, GameObject gameScene, EndGameHandler endGameHandler)
        {
            _mainMenu = mainMenu;
            _gameScene = gameScene;
            _endGame = endGameHandler;
        }

        public void OnGameStateChange(GameState state)
        {
            switch (state)
            {
                case GameState.MainMenu:
                    Debug.LogWarning("Now you in a Main Menu");
                    _gameScene.SetActive(false);
                    _mainMenu.SetActive(true);
                    break;

                case GameState.Start:
                    Debug.LogWarning("Game is started");
                    _mainMenu.SetActive(false);
                    _gameScene.SetActive(true);
                    break;
                
                case GameState.Exit:
                    Debug.LogWarning("Exit");
                    _endGame.ExitPressed = true;
                    break;
            }
        }
    }
}