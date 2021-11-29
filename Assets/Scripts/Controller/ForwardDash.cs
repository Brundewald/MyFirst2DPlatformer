using Model;
using UnityEngine;

namespace Controller
{
    public class ForwardDash:IAbility
    {
        private readonly DashParameters _dashParameters;
        private readonly SpriteRenderer _characterSpriteRenderer;
        private Rigidbody2D _characterRigidbody;

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
            Vector2 positionBeforeDash = _characterRigidbody.transform.position;
            var dashPosition = new Vector2(_dashParameters.DashDistance,0);
            var lookForward = _characterSpriteRenderer.flipX is false;
        
            if(lookForward)
                _characterRigidbody.MovePosition(positionBeforeDash + dashPosition);
            else
                _characterRigidbody.MovePosition(positionBeforeDash - dashPosition);
        }
    }
}