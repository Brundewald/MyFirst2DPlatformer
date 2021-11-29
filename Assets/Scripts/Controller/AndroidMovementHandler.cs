using UnityEngine;
using Model;
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
        private readonly GameObject _scene;
        private readonly CharacterControlView _characterControllerView;
        private readonly DashParameters _dashParameters;
        private readonly ForwardDash _forwardDash;

        private SpriteRenderer _characterSpriteRenderer;
        private Transform _characterTransform;
        private Rigidbody2D _characterRigidbody2D;
        private RectTransform _rightArrow;
        private RectTransform _leftArrow;
        private RectTransform _upArrow;
        private TouchHandler _touchHandler;

        private float _jumpHeight;
        private float _horizontal;
        private float _vertical;
        private bool _doJump;

        public AndroidMovementHandler(CharacterModel characterModel, AnimationHandler animator,
            CharacterView characterView, CollisionHandler collisionHandler, CharacterControlView characterControlView, 
            GameObject scene, DashParameters dashParameters)
        {
            _characterModel = characterModel;
            _characterView = characterView;
            _animator = animator;
            _collisionHandler = collisionHandler;
            _scene = scene;
            _characterControllerView = characterControlView;
            _dashParameters = dashParameters;
            _touchHandler = new TouchHandler();
            _touchHandler.TouchHandlerInit(this);
            
            _characterTransform = _characterView.transform;
            _characterSpriteRenderer = _characterView.CharacterSpriteRenderer;
            _characterRigidbody2D = _characterView.CharacterRigidbody2D;
            _jumpHeight = _characterModel.JumpHeight;
            _rightArrow = _characterControllerView.RightArrow.GetComponent<RectTransform>();
            _leftArrow = _characterControllerView.LeftArrow.GetComponent<RectTransform>();
            _upArrow = _characterControllerView.UpArrow.GetComponent<RectTransform>();
            _forwardDash = new ForwardDash(dashParameters, _characterRigidbody2D, _characterSpriteRenderer);
            _characterControllerView.Init(Pause, Dash);
        }

        private void Dash()
        {
            _forwardDash.UseAbility();
        }

        private void Pause()
        {
        }

        public void Execute(float deltaTime)
        {
            if (_scene.activeInHierarchy)
            {
                _touchHandler.GetTouch();

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
        }

        public void LateExecute(float deltaTime)
        {
            if (_doJump && _collisionHandler.IsGrounded)
            {
                _characterRigidbody2D.AddForce(new Vector2(0f, _jumpHeight), ForceMode2D.Impulse);
                _animator.JumpAnimation();
            }
        }

        public void SetToZero()
        {
            _horizontal = 0;
            _vertical = 0;
        }

        public void CheckTouchedButton(TouchLocation thisTouch)
        {
            if (ArrowTapped(_rightArrow, thisTouch))
            {
                _horizontal = 1;
            }
            else if (ArrowTapped(_leftArrow, thisTouch))
            {
                _horizontal = -1;
            }
            else if (ArrowTapped(_upArrow, thisTouch))
            {
                _vertical = 1;
            }
        }
        
        private bool ArrowTapped(RectTransform rect, TouchLocation thisTouch)
        {
            var arrowTapped = RectTransformUtility.RectangleContainsScreenPoint(rect,thisTouch.Touch.transform.position);
            return arrowTapped;
        }

        public GameObject CreateTouchObject(int touchFingerId, Touch thisTouch)
        {
            GameObject touchObject = new GameObject();
            touchObject.transform.SetParent(_characterControllerView.transform);
            touchObject.transform.position = GetTouchPosition(thisTouch.position);
            touchObject.name = $"Touch {touchFingerId}";
            return touchObject;
        }

        private Vector2 GetTouchPosition(Vector2 touchPosition)
        {
            return Camera.main.ScreenToWorldPoint(touchPosition);
        }

        private void SidewayMovement()
        {
            var speed = _characterModel.Speed * Time.deltaTime;
            _characterTransform.localPosition += Vector3.right * _horizontal * speed;

            if (!Mathf.Approximately(_horizontal,0))
            {
                if (_horizontal < 0)
                {
                    _characterSpriteRenderer.flipX = true;

                    if (_collisionHandler.IsGrounded)
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