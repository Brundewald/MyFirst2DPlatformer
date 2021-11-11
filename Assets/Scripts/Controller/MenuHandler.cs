using UnityEngine;
using View;

namespace Controller
{
    public class MenuHandler:IInitialize
    {
        private MainMenuView _mainMenuView;
        public MenuHandler(MainMenuView mainMenuView)
        {
            _mainMenuView = mainMenuView;
            _mainMenuView.Init(StartMessage, ExitMessage);
        }

        private void ExitMessage()
        {
            Debug.LogError("Exit");
        }

        private void StartMessage()
        {
            Debug.LogError("Start");
        }

        public void Initialize()
        {
            
        }
    }
}