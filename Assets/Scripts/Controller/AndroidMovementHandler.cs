using UnityEngine;
using Model;
using UnityEngine.UI;
using View;

namespace Controller
{
    public class AndroidMovementHandler : IExecute, ILateExecute
    {
        private readonly IUserInputProxy _inputProxyHorizontal;
        private readonly IUserInputProxy _inputProxyVertical;
        private readonly CharacterModel _characterModel;
        private readonly AnimationHandler _animator;
        private readonly CharacterView _characterView;
        private readonly CollisionHandler _collisionHandler;
        private readonly CharacterControlView _characterControlView;
        
        private SpriteRenderer _characterSpriteRenderer;
        private Transform _characterTransform;
        private Rigidbody2D _characterRigidbody2D;
        private Button _buttonRight;
        
        private float _jumpHeight;
        private float _horizontal;
        private float _vertical;
        private bool _doJump;
        private bool _moveRight;
        private bool _moveLeft;
        
        public AndroidMovementHandler(CharacterModel characterModel, AnimationHandler animator, CharacterView characterView,
            CollisionHandler collisionHandler, CharacterControlView characterControlView)
        {
            _characterModel = characterModel;
            _characterView = characterView;
            _animator = animator;
            _collisionHandler = collisionHandler;
            _characterControlView = characterControlView;

            _characterTransform = _characterView.transform;
            _characterSpriteRenderer = _characterView.CharacterSpriteRenderer;
            _characterRigidbody2D = _characterView.CharacterRigidbody2D;
            _jumpHeight = _characterModel.JumpHeight;
            _buttonRight = _characterControlView.RightArrow;
            _characterControlView.Init(MoveLeft, MoveRight, Jump);
        }

        
        private void MoveRight()
        {
            _moveRight = true;
        }

        private void MoveLeft()
        {
            var speed = _characterModel.Speed * Time.deltaTime;
            _characterTransform.localPosition += Vector3.left * speed;

            _characterSpriteRenderer.flipX = false;
           
            if (_collisionHandler.IsGrounded) 
                _animator.MoveAnimation();
        }

        private void Jump()
        {
        }

        public void Execute(float deltaTime)
        {   
            Debug.LogWarning(_moveRight);
            var isGoingSidway = Mathf.Abs(_characterRigidbody2D.velocity.x) > 0;

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

        
    }
}