using UnityEngine;
using View;

namespace Controller
{
    public class ParalaxManager : IExecute
    {
        private const float Coef = 1;

        private readonly Camera _camera;
        private Transform _backgroundTransform;
        private Vector3 _cameraStartPosition;
        private Vector3 _backStartPosition;

        public ParalaxManager(Camera camera, BackgroundView backgroundView)
        {
            _camera = camera;
            _backgroundTransform = backgroundView.GetComponent<Transform>();
            _cameraStartPosition = _backgroundTransform.position;
            _backStartPosition = _backgroundTransform.position;
        }

        public void Execute(float deltaTime)
        {
            _backgroundTransform.position = _backStartPosition + (_camera.transform.position - _cameraStartPosition) * Coef;
        }
    }
}

