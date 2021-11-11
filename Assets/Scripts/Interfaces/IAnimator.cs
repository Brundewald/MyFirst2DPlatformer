using UnityEngine;

namespace Controller
{
    public interface IAnimator
    {
        Animator CharacterAnimator();
        Animator FinishAnimator();
    }
}
