using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controller
{
    public class PointerTrailHandler: IExecute
    {
        private Transform _trailOrigin;
        private GameObject _trailSource;
        private List<TouchLocation> _touchLocations = new List<TouchLocation>();
        private readonly GameObject _mainMenu;

        public PointerTrailHandler(Transform parent, GameObject trailObject, GameObject mainMenu)
        {
            _trailOrigin = parent;
            _trailSource = trailObject;
            _mainMenu = mainMenu;
        }


        public void Execute(float deltaTime)
        {
            if (_mainMenu.activeInHierarchy)
            {
                int index = 0;

                while (index < Input.touchCount)
                {
                    Touch touch = Input.GetTouch(index);
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            _touchLocations.Add(new TouchLocation(touch.fingerId, CreateTrail(touch.fingerId)));
                            break;
                        case TouchPhase.Moved:
                            TouchLocation thisTouchTrail = GetThisTouch(touch);
                            thisTouchTrail.Touch.transform.position = TouchPosition(touch.position);
                            break;
                        case TouchPhase.Ended:
                            TouchLocation touchTrailToDelete = GetThisTouch(touch);
                            Object.Destroy(touchTrailToDelete.Touch);
                            _touchLocations.RemoveAt(_touchLocations.IndexOf(touchTrailToDelete));
                            break;
                    }
                    index++;
                }   
            }
        }

        private Vector2 TouchPosition(Vector2 touchPosition)
        {
            return Camera.main.ScreenToWorldPoint(touchPosition);
        }

        private TouchLocation GetThisTouch(Touch touch)
        {
            TouchLocation thisTouchTrail =
                _touchLocations.Find(location => location.TouchIndex == touch.fingerId);
            return thisTouchTrail;
        }
        private GameObject CreateTrail(int index)
        {
            GameObject trail = Object.Instantiate(_trailSource, _trailOrigin);
            trail.name = $"Trail + {index}";
            return trail;
        }
    }
}