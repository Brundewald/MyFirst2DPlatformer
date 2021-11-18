using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controller
{
    public class PointerTrailHandler: IExecute
    {
        private Transform _trailOrigin;
        private GameObject _trailSource;
        private List<TouchTrailLocation> _touchLocations = new List<TouchTrailLocation>();
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
                            _touchLocations.Add(new TouchTrailLocation(touch.fingerId, CreateTrail(touch.fingerId)));
                            break;
                        case TouchPhase.Moved:
                            TouchTrailLocation thisTouchTrail = GetThisTouch(touch);
                            thisTouchTrail.TrailSource.transform.position = TouchPosition(touch.position);
                            break;
                        case TouchPhase.Ended:
                            TouchTrailLocation touchTrailToDelete = GetThisTouch(touch);
                            Object.Destroy(touchTrailToDelete.TrailSource);
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

        private TouchTrailLocation GetThisTouch(Touch touch)
        {
            TouchTrailLocation thisTouchTrail =
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