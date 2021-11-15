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

        public PointerTrailHandler(Transform parent, GameObject trailObject)
        {
            _trailOrigin = parent;
            _trailSource = trailObject;
        }


        public void Execute(float deltaTime)
        {
            int index = 0;

            while (index < Input.touchCount)
            {
                Touch touch = Input.GetTouch(index);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.LogWarning("Touch Began");
                        _touchLocations.Add(new TouchLocation(touch.fingerId, CreateTrail(touch.fingerId)));
                        break;
                    case TouchPhase.Moved:
                        Debug.LogWarning("Touch Moved");
                        TouchLocation thisTouch = GetThisTouch(touch);
                        thisTouch.TrailSource.transform.position = TouchPosition(touch.position);
                        break;
                    case TouchPhase.Ended:
                        Debug.LogWarning("Touch Ended");
                        TouchLocation touchToDelete = GetThisTouch(touch);
                        Object.Destroy(touchToDelete.TrailSource);
                        _touchLocations.RemoveAt(_touchLocations.IndexOf(touchToDelete));
                        break;
                }
                index++;
            }
        }

        private Vector2 TouchPosition(Vector2 touchPosition)
        {
            return Camera.main.ScreenToWorldPoint(touchPosition);
        }

        private TouchLocation GetThisTouch(Touch touch)
        {
            TouchLocation thisTouch =
                _touchLocations.Find(location => location.TouchIndex == touch.fingerId);
            return thisTouch;
        }
        private GameObject CreateTrail(int index)
        {
            GameObject trail = Object.Instantiate(_trailSource, _trailOrigin);
            trail.name = $"Trail + {index}";
            return trail;
        }
    }
}