using UnityEngine;

namespace Controller
{
    public class PointerTrailHandler: IExecute
    {
        private readonly GameObject _mainMenu;
        private Transform _trailOrigin;
        private GameObject _trailSource;
        private TouchHandler _touchHandler;
        public PointerTrailHandler(Transform parent, GameObject trailObject, GameObject mainMenu)
        {
            _trailOrigin = parent;
            _trailSource = trailObject;
            _mainMenu = mainMenu;
            _touchHandler = new TouchHandler();
            _touchHandler.TouchHandlerInit(this);
        }

        public void Execute(float deltaTime)
        {
            if (_mainMenu.activeInHierarchy)
            {
                _touchHandler.GetTouch(); 
            }
        }

        public void GetTouchPosition(TouchLocation thisTouchTrail, Touch touch)
        {
            thisTouchTrail.Touch.transform.position = TouchPosition(touch.position);
        }

        private Vector2 TouchPosition(Vector2 touchPosition)
        {
            return Camera.main.ScreenToWorldPoint(touchPosition);
        }

        public GameObject CreateTrail(int index)
        {
            GameObject trail = Object.Instantiate(_trailSource, _trailOrigin);
            trail.name = $"Trail + {index}";
            return trail;
        }
    }
}