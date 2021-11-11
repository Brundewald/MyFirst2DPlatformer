using UnityEngine;
using Model;
using View;

namespace Controller
{
    public class MovementHandler : IExecute, ILateExecute, ICleanup
    {
        private readonly IUserInputProxy _inputProxyHorizontal;
        private readonly IUserInputProxy _inputProxyVertical;
        private readonly CharacterModel _characterModel;
        private readonly AnimationHandler _animator;
        private readonly CharacterView _characterView;
        private readonly CollisionHandler _collisionHandler;
        
        private SpriteRenderer _characterSpriteRenderer;
        private Transform _characterTransform;
        private Rigidbody2D _characterRigidbody2D;
        
        private float _jumpHeight;
        private float _currentHeight;
        private float _horizontal;
        private float _vertical;
        private bool _doJump;
        
        public MovementHandler((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            CharacterModel characterModel, AnimationHandler animator, CharacterView characterView, CollisionHandler collisionHandler)
        {
            _characterModel = characterModel;
            _characterView = characterView;
            _animator = animator;
            _collisionHandler = collisionHandler;

            _characterTransform = _characterView.transform;
            _characterSpriteRenderer = _characterView.CharacterSpriteRenderer;
            _characterRigidbody2D = _characterView.CharacterRigidbody2D;
            _jumpHeight = _characterModel.JumpHeight;


            _inputProxyHorizontal = input.inputHorizontal;
            _inputProxyVertical = input.inputVertical;
            _inputProxyHorizontal.OnAxisChange += InputProxyHorizontalOnAxisChange;
            _inputProxyVertical.OnAxisChange += InputProxyVerticalOnAxisChange;
        }

        private void InputProxyVerticalOnAxisChange(float value)
        {
            _vertical = value;
        }

        private void InputProxyHorizontalOnAxisChange(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltaTime)
        {
            var isGoingSidway = Mathf.Abs(_horizontal) > 0;

            if (_collisionHandler.IsGrounded)
                _doJump = _vertical > 0;
            
            if (isGoingSidway)
            {
                SidewayMovement();
            }

            if (!isGoingSidway && _collisionHandler.IsGrounded)
            {
                _animator.IdleAnimation();
            }
        }

        public void LateExecute(float deltaTime)
        {
            if (_doJump && _collisionHandler.IsGrounded)
            {
                _characterRigidbody2D.AddForce(new Vector2(0f, _jumpHeight), ForceMode2D.Impulse);
                _animator.JumpAnimation();
            }
        }

        private void SidewayMovement()
        {
            var speed = _characterModel.Speed * Time.deltaTime;
            _characterTransform.localPosition += Vector3.right * _horizontal * speed;
            
            if (_horizontal != 0)
            {
                if (_horizontal < 0)
                {
                    _characterSpriteRenderer.flipX = true;
                   
                    if(_collisionHandler.IsGrounded)
                        _animator.MoveAnimation();
                }
                else
                {
                    _characterSpriteRenderer.flipX = false;

                    if (_collisionHandler.IsGrounded)
                        _animator.MoveAnimation();
                }
            }
        }

        public void Cleanup()   
        {
            _inputProxyHorizontal.OnAxisChange -= InputProxyHorizontalOnAxisChange;
            _inputProxyVertical.OnAxisChange -= InputProxyVerticalOnAxisChange;
        }
    }
}
