
using UnityEngine;
using View;

namespace Controller
{
    public class AnimatorInitialization : IAnimator, IInitialize
    {
        private Animator _characterAnimator;
        private Animator _finishAnimator;
        private Animator _enemyAnimator;

        public AnimatorInitialization(CharacterView characterView, FinishView finishView, EnemyView enemyView)
        {
            _characterAnimator = characterView.Animator;
            _finishAnimator = finishView.Animator;
            _enemyAnimator = enemyView.Animator;
        }

        public Animator CharacterAnimator()
        {
            return _characterAnimator;
        }

        public Animator FinishAnimator()
        {
            return _finishAnimator;
        }

        public Animator EnemyAnimator()
        {
            return _enemyAnimator;
        }

        public void Initialize()
        {
        }
    }
}
