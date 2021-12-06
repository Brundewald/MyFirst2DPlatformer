using DG.Tweening;
using UnityEngine;
using View;

namespace Controller
{
    public class CharacterDeathHandler:IInitialize, ICleanup
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

        public void Initialize()
        {
            _collisionHandler.OnPlayerCaught += ReviveBlinking;
        }

        public void Cleanup()
        {
            _collisionHandler.OnPlayerCaught -= ReviveBlinking;
        }

        private void ReviveBlinking()
        {
            _dropScoreHandler.ResetScore();
            _characterView.transform.position = _characterSpawn.position;
            var renderer = _characterView.CharacterSpriteRenderer;
            renderer.transform.DOPunchRotation(Vector3.down, 3, 5);
        }
    }
}