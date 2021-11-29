using UnityEngine;
using View;

namespace Controller
{
    public class CharacterDeathHandler:ILateExecute
    {
        private CollisionHandler _collisionHandler;
        private DropScoreHandler _dropScoreHandler;
        private CharacterView _characterView;
        private Transform _characterSpawn;
        
        public CharacterDeathHandler(CollisionHandler collisionHandler, DropScoreHandler dropScoreHandler, CharacterView characterView)
        {
            _collisionHandler = collisionHandler;
            _dropScoreHandler = dropScoreHandler;
            _characterView = characterView;
            
            _characterSpawn = _characterView.CharacterSpawn;
        }

        public void LateExecute(float deltaTime)
        {
            if (_collisionHandler.CharacterCaught)
            {
                _dropScoreHandler.ResetScore();
                _characterView.transform.position = _characterSpawn.position;
                _collisionHandler.CharacterCaught = false;
            }
        }
    }
}