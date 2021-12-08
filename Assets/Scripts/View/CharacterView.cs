using UnityEngine;

namespace View
{
    public class CharacterView : MonoBehaviour
    {
        [Header("Properties")]
        [Tooltip("Drag&drop here character object with SpriteRenderer.")][SerializeField] 
        private SpriteRenderer _spriteRenderer;
        
        [Tooltip("Drag&drop here character object with Rigidbody2D.")][SerializeField] 
        private Rigidbody2D _rigidbody2D;
        
        [Tooltip("Drag&drop here character object with Collider.")][SerializeField]
        private Collider2D _collider2D;
        
        [Tooltip("Drag&drop here character object with Animator.")][SerializeField] 
        private Animator _animator;
        
        [Tooltip("Drag&Drop Character spawn object here")] [SerializeField]
        private Transform _characterSpawn;

        public Transform CharacterSpawn => _characterSpawn;
        public Animator Animator => _animator;
        public SpriteRenderer CharacterSpriteRenderer => _spriteRenderer;
        public Rigidbody2D CharacterRigidbody2D => _rigidbody2D;
        public Collider2D Collider2D => _collider2D;

    }
}

