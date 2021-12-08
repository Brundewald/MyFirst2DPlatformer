using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Controller
{
    public class TweenHandler:IInitialize, ICleanup
    {
        private readonly ForwardDash _forwardDash;

        public TweenHandler(ForwardDash forwardDash)
        {
            _forwardDash = forwardDash;
        }

        public void Initialize()
        {
            _forwardDash.DoDash += DoDashTweenAnimation;
        }

        public void Cleanup()
        {
            _forwardDash.DoDash -= DoDashTweenAnimation;
        }

        private void DoDashTweenAnimation(float distance, float speed, Rigidbody2D rigidbody2D)
        {
            rigidbody2D.transform.DOLocalMoveX(distance, speed).SetEase(Ease.OutFlash);
        }
    }
}