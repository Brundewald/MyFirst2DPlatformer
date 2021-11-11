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
        private Transform _enemyTransform;
        private AIDestinationSetter _aiDestinationSetter;
        private AnimationHandler _animation;


        public EnemyHandler(EnemyView enemyView, CharacterView characterView, Transform basePoint, AnimationHandler animationHandler)
        {
            _enemyReactionDistance = enemyView.ReactionDistance;
            _enemyTransform = enemyView.Transform;
            _aiDestinationSetter = enemyView.DestinationSetter;

            _basePoint = basePoint;

            _animation = animationHandler;

            _characterTransform = characterView.transform;
        }

        public void Execute(float deltaTime)
        {
            var distance = (_characterTransform.position - _enemyTransform.position).magnitude;

            if (distance < _enemyReactionDistance)
            {
                Debug.Log("Player in sight!");
                _aiDestinationSetter.target = _characterTransform;
            }
            else
            {
                _aiDestinationSetter.target = _basePoint;
            }

            _animation.EnemyMovement();
        }

        public void Initialize()
        {
        }
    }
}