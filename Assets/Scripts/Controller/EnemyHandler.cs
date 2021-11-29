using Pathfinding;
using UnityEngine;
using View;

namespace Controller
{
    public class EnemyHandler: IExecute, IInitialize
    {
        private readonly float _enemyReactionDistance;
        private readonly Transform _characterTransform;
        private readonly Transform _basePoint;
        private readonly GameObject _scene;
        private readonly EnemyAIHandler _enemyAiHandler;

        private Transform _enemyTransform;
        private AIDestinationSetter _aiDestinationSetter;
        private AnimationHandler _animation;


        public EnemyHandler(EnemyView enemyView, CharacterView characterView, EnemyAIHandler enemyAiHandler,Transform basePoint, AnimationHandler animationHandler, GameObject scene)
        {
            _enemyReactionDistance = enemyView.ReactionDistance;
            _enemyTransform = enemyView.Transform;
            _aiDestinationSetter = enemyView.DestinationSetter;
            _enemyAiHandler = enemyAiHandler;
            _scene = scene;
            _animation = animationHandler;
            _basePoint = basePoint;

            _characterTransform = characterView.transform;
        }

        public void Execute(float deltaTime)
        {
            if (_scene.activeInHierarchy&&_enemyTransform.gameObject.activeInHierarchy)
            {
               
                if (_enemyAiHandler.IsCharacterStoleApple())
                    _aiDestinationSetter.target = _characterTransform;
                else
                    _aiDestinationSetter.target = _basePoint;
               
                _animation.EnemyMovement();
            }
        }

        public void Initialize()
        {
        }
    }
}