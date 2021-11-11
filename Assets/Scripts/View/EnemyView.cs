using Pathfinding;
using UnityEngine;


namespace View
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class EnemyView : MonoBehaviour
    {
            [SerializeField] private float _reactionDistance;
            [SerializeField] private Animator _animator;
            [SerializeField] private Transform _transform;
            [SerializeField] private AIDestinationSetter _aiDestinationSetter;
          
            public float ReactionDistance => _reactionDistance;
            public Animator Animator => _animator;
            public Transform Transform => _transform;
            public AIDestinationSetter DestinationSetter => _aiDestinationSetter;
    }
}

