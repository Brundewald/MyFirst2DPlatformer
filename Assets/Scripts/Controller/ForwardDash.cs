using Model;
using UnityEngine;

namespace Controller
{
    public class ForwardDash:IAbility
    {
        private readonly DashParameters _dashParameters;
        private readonly SpriteRenderer _characterSpriteRenderer;
        private Rigidbody2D _characterRigidbody;
        private Vector2 _positionBeforeDash;

        public ForwardDash(DashParameters dashParameters, Rigidbody2D characterRigidbody, SpriteRenderer spriteRenderer)
        {
            _dashParameters = dashParameters;
            _characterRigidbody = characterRigidbody;
            _characterSpriteRenderer = spriteRenderer;
        }

        public void UseAbility()
        {
            CompleteDash();
        }

        private void CompleteDash()
        {
            _positionBeforeDash = _characterRigidbody.transform.position;
            var lookForward = _characterSpriteRenderer.flipX is false;
            switch (lookForward)
            {
                case true:
                    _characterRigidbody.MovePosition(_positionBeforeDash+new Vector2(_dashParameters.DashDistance,0));
                    break;
                case false:
                    _characterRigidbody.MovePosition(_positionBeforeDash-new Vector2(_dashParameters.DashDistance,0));
                    break;
            }
            
        }
    }
}