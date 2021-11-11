using UnityEngine;
using View;

namespace Controller
{
    public class CameraController:ILateExecute
    {
        private readonly Transform _characterTransform;
        private readonly Camera _camera;
        private readonly Vector3 _cameraOffset;

        public CameraController(Camera camera, CharacterView characterView)
        {
            _camera = camera;
            _characterTransform = characterView.GetComponent<Transform>();
            _cameraOffset = _camera.transform.position - _characterTransform.position;
        }

        public void LateExecute(float deltaTime)
        {
            var destination = _characterTransform.position + _cameraOffset;
            _camera.transform.position = Vector2.Lerp(_camera.transform.position, destination, deltaTime*5);
        }
    }
}
