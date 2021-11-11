using UnityEditor;
using UnityEngine;
using View;

namespace Controller
{
    public class CollisionHandler: IExecute, ILateExecute
    {
        private const float _rayDistance = 0.03f;
        private int _groundLayerMask = 1 << 6;
        private readonly Collider2D _characterCollider;
        private Vector2 _rayDirectionDown = new Vector2(0f, -1f);
        private const float _offset = 0.005f;
        private bool _getScore;
        private bool _isFinished;
        public CollisionHandler(CharacterView characterView)
        {
            _characterCollider = characterView.Collider2D;
        }

        public void Execute(float deltaTime)
        {
            OnGroundCheck();
            Debug.LogWarning(OnGroundCheck());
        }

        public void LateExecute(float deltaTime)
        {
            CollisionDetection();
        }

        private void CollisionDetection()
        {
              Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(_characterCollider.bounds.center, 0.2f);

              foreach (var vCollider2D in collider2Ds)
              {
                  Debug.LogWarning(vCollider2D.name);
                  if (vCollider2D.GetComponent<BonusView>())
                  {
                      Debug.LogError("Here is your Score");
                      _getScore = true;
                      Object.Destroy(vCollider2D.gameObject);
                  }

                  if (vCollider2D.GetComponent<FinishView>())
                  {
                      Debug.LogError("Finish is reached");
                      _isFinished = true;
                  }
              }
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

        public bool GetScore
        {
            set { _getScore = value;}

            get { return _getScore; }
        }

        public bool IsFinished
        {
            set {
                _isFinished = value;
            }

            get {
                return _isFinished;
            }
        }
    }
}