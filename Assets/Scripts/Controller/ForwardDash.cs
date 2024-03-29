﻿using System;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ForwardDash:IAbility
    {
        private readonly DashParameters _dashParameters;
        private readonly SpriteRenderer _characterSpriteRenderer;
        private readonly CharacterControlView _characterControlView;
        private Rigidbody2D _characterRigidbody;
        
        public event Action<float, float, Rigidbody2D> DoDash = delegate(float position, float speed, Rigidbody2D rigidbody2D) {  }; 

        public ForwardDash(DashParameters dashParameters, ViewReferenceHolder view)
        {
            _dashParameters = dashParameters;
            _characterRigidbody = view.CharacterView.CharacterRigidbody2D;
            _characterSpriteRenderer = view.CharacterView.CharacterSpriteRenderer;
            _characterControlView = view.CharacterControlView;
            _characterControlView.Init(Pause, UseAbility);
        }

        private void Pause()
        {
        }

        public void UseAbility()
        {
            CompleteDash();
        }

        private void CompleteDash()
        {
            var positionBeforeDash = _characterRigidbody.transform.position.x;
            var dashPosition = _dashParameters.DashDistance;
            var lookForward = !_characterSpriteRenderer.flipX;

            float dashDistance;
            
            if(lookForward)
                dashDistance = positionBeforeDash + dashPosition;
            else
                dashDistance = positionBeforeDash - dashPosition;
            
            DoDash?.Invoke(dashDistance, _dashParameters.DashDuration, _characterRigidbody);
        }
    }
}