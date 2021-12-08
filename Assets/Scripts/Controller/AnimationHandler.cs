
using UnityEngine;

namespace Controller
{
    public class AnimationHandler 
    {
        private Animator _characterAnimator;
        private Animator _finishAnimator;
        private Animator _enemyAnimator;
        private const string _characterIdle = "Character_Idle";
        private const string _characterMove = "Character_Move";
        private const string _characterJump = "Character_Jump";
        private const string _characterFinished = "Finish_Animation";
        private const string _enemyMovement = "Enemy_Movement";

        public AnimationHandler(AnimatorInitialization animatorInitialization)
        {
            _characterAnimator = animatorInitialization.CharacterAnimator();
            _finishAnimator = animatorInitialization.FinishAnimator();
            _enemyAnimator = animatorInitialization.EnemyAnimator();
        }

        public void IdleAnimation()
        {
            _characterAnimator.Play(_characterIdle);
        }

        public void MoveAnimation()
        {
            _characterAnimator.Play(_characterMove);
        }

        public void JumpAnimation()
        {
            _characterAnimator.Play(_characterJump);
        }

        public void FinishAnimation()
        {
            _finishAnimator.Play(_characterFinished);
        }

        public void EnemyMovement()
        {
            _enemyAnimator.Play(_enemyMovement);
        }
    }
}
