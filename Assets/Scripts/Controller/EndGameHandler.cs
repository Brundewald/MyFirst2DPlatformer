using UnityEngine;
using View;

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
        

        public EndGameHandler(CollisionHandler collisionHandler, AnimationHandler animatorHandler, ModelReferenceHolder models, ObjectReferenceHolder objects)
        {
            _collisionHandler = collisionHandler;
            _scoreHolder = models.ScoreHolder;
            _requireScore = models.LevelModel.RequireScore;
            _animator = animatorHandler;
            _endGameDisplayPath = models.LevelModel.EndGameDisplayPath;
            _endGameDisplayPrefab = Resources.Load<GameObject>(_endGameDisplayPath);
            _scene = objects.LevelObject;
        }

        public void LateExecute(float deltaTime)
        {
            EndGameMessage();
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
                    }
                }    
            }
        }
    }
}