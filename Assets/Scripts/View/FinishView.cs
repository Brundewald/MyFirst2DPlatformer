using UnityEngine;

namespace View
{
    public class FinishView:MonoBehaviour
    {
        [Header("Animator")][Tooltip("Drag&drop here finish object with Animator.")]
        [SerializeField] private Animator _animator;

        public Animator Animator => _animator;
    }
}