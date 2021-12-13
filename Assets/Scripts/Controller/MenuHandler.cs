using View;

namespace Controller
{
    public class MenuHandler : IInitialize
    {
        private readonly MainMenuView _mainMenuView;
        private readonly CharacterControlView _characterControlView;
        private GameStateHandler _gameStateHandler;

        public MenuHandler(ViewReferenceHolder view, GameStateHandler gameStateHandler)
        {
            _mainMenuView = view.MainMenuView;
            _mainMenuView.Init(Start, Exit, RewardScreen);
            _characterControlView = view.CharacterControlView;
            _characterControlView.Init(GoToMainMenu, ForwardDash);

            _gameStateHandler = gameStateHandler;
        }

        private void ForwardDash()
        {
        }

        private void GoToMainMenu()
        {
            _gameStateHandler.OnGameStateChange(GameState.MainMenu);
        }

        private void RewardScreen()
        {
            _gameStateHandler.OnGameStateChange(GameState.Reward);
        }

        private void Exit()
        {
            _gameStateHandler.OnGameStateChange(GameState.Exit);
        }

        private void Start()
        {
            _gameStateHandler.OnGameStateChange(GameState.Start);
        }

        public void Initialize() {}
    }
}