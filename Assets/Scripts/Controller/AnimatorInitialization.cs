
using UnityEngine;
using View;

namespace Controller
{
    public class AnimatorInitialization : IAnimator, IInitialize
    {
        private Animator _characterAnimator;
        private Animator _finishAnimator;
        private Animator _enemyAnimator;

        public AnimatorInitialization(ViewReferenceHolder view)
        {
            _characterAnimator = view.CharacterView.Animator;
            _finishAnimator = view.FinishView.Animator;
            _enemyAnimator = view.EnemyView.Animator;
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
