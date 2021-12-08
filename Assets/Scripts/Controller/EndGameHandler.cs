using UnityEngine;

namespace Controller
{
    public sealed class EndGameHandler: ILateExecute
    {
        private readonly string _endGameDisplayPath;
        private readonly ScoreHolder _scoreHolder;
        private readonly CollisionHandler _collisionHandler;
        private readonly GameObject _scene;
        private readonly int _requireScore;
        
        private AnimationHandler _animator;
        private GameObject _endGameDisplayPrefab;
        private GameObject _endGameDisplay;
        private GameObject _enemyObject;
        
        private bool _isExitPressed;

        public EndGameHandler(CollisionHandler collisionHandler, AnimationHandler animatorHandler, ScoreHolder scoreHolder,
            LevelDataModel levelData, GameObject gameObject, GameObject scene)
        {
            _collisionHandler = collisionHandler;
            _scoreHolder = scoreHolder;
            _requireScore = levelData.RequireScore;
            _animator = animatorHandler;
            _endGameDisplayPath = levelData.EndGameDisplayPath;
            _endGameDisplayPrefab = Resources.Load<GameObject>(_endGameDisplayPath);
            _enemyObject = gameObject;
            _scene = scene;
        }

        public void LateExecute(float deltaTime)
        {
            EndGameMessage();
            GameExit();
        }

        private void GameExit()
        {
            if (_isExitPressed)
                Application.Quit();
        }

        private void EndGameMessage()
        {
            var score = _scoreHolder.ScoreCount;
            if (_scene.activeInHierarchy)
            {
                if (score < _requireScore)
                    _collisionHandler.IsFinished = false;
            
                else if (_collisionHandler.IsFinished && score >= _requireScore)
                {
                    _animator.FinishAnimation();
                    if (_endGameDisplay is null)
                    {
                        _endGameDisplay = Object.Instantiate(_endGameDisplayPrefab);
                        _enemyObject.SetActive(false);
                    }
                }    
            }
        }
        
        public bool ExitPressed
        {
            set { _isExitPressed = value;}
        }
    }
}