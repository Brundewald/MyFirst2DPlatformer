using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Data/CharacterData", fileName = "CharacterData")]
    public class CharacterModel : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpHeight;
        
        public float Speed => _speed;
        public float JumpHeight => _jumpHeight;
    }
}
