using UnityEngine;

namespace View
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;

        public SpriteRenderer CharacterSpriteRenderer => _spriteRenderer;
        public Rigidbody2D CharacterRigidbody2D => _rigidbody2D;
        public Collider2D Collider2D => _collider2D;

    }
}

