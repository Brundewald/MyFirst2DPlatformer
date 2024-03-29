﻿using System;
using System.Threading.Tasks;
using UnityEngine;
using View;
using Object = UnityEngine.Object;

namespace Controller
{
    public class CollisionHandler: IExecute, ILateExecute
    {
        private const float _rayDistance = 0.03f;
        private int _groundLayerMask = 1 << 6;
        private readonly Collider2D _characterCollider;
        private Vector2 _rayDirectionDown = new Vector2(0f, -1f);
        private const float _offset = 0.005f;
        private int _scoreForApple;
        private bool _isFinished;

        public event Action<int, GameObject> OnGettingScore = delegate(int i, GameObject gameObject) {  };
        public event Action OnPlayerCaught = delegate() { };
        
        public CollisionHandler(CharacterView characterView, ScoreHolder scoreHolder)
        {
            _scoreForApple = scoreHolder.ScoreForApple;
            _characterCollider = characterView.Collider2D;
        }

        public void Execute(float deltaTime)
        {
            OnGroundCheck();
        }

        public void LateExecute(float deltaTime)
        {
            CollisionDetectionAsync();
        }

        private async void CollisionDetectionAsync()
        {
              Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(_characterCollider.bounds.center, 0.15f);

              foreach (var vCollider2D in collider2Ds)
              {
                  CheckColliderAsync(vCollider2D);
              }

              await Task.Yield();
        }

        private async void CheckColliderAsync(Collider2D vCollider2D)
        {
            if (vCollider2D.GetComponentInParent<BonusView>())
            {
                if (vCollider2D.gameObject.activeInHierarchy)
                    OnGettingScore?.Invoke(_scoreForApple, vCollider2D.gameObject);
                else
                    return;
            }

            if (vCollider2D.GetComponent<FinishView>())
            {
                _isFinished = true;
            }

            if (vCollider2D.GetComponent<EnemyView>())
            {
                OnPlayerCaught?.Invoke();
            }

            await Task.Yield();
        }

        private bool OnGroundCheck()
        {
            var bounds = _characterCollider.bounds;
            var originVector = new Vector2(bounds.center.x, (bounds.center.y - (bounds.extents.y+_offset)));

            Collider2D raycastHit2D = Physics2D.OverlapCircle(originVector, 0.06f, _groundLayerMask);

            Color rayColor;

            if (raycastHit2D != null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(originVector, _rayDirectionDown*_rayDistance, rayColor);
            
            return raycastHit2D != null;
        }

        public bool IsGrounded => OnGroundCheck();


        public bool IsFinished
        {
            internal set {_isFinished = value;}

            get {return _isFinished;}
        }
    }
}