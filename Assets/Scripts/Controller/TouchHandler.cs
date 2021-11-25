using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class TouchHandler
    {
        private AndroidMovementHandler _androidMovementHandler;
        private PointerTrailHandler _pointerTrailHandler;
        private List<TouchLocation> _touchLocations = new List<TouchLocation>();

        public TouchHandler()
        {
        }

        public void TouchHandlerInit(object callingClass)
        {
            if (callingClass is AndroidMovementHandler androidMovementHandler)
                _androidMovementHandler = androidMovementHandler;
            if (callingClass is PointerTrailHandler pointerTrailHandler)
                _pointerTrailHandler = pointerTrailHandler;
        }
        
        private void GetTouchedButton(GameObject touchObject)
        {
            int index = 0;

            while (index < Input.touchCount)
            {
                Touch touch = Input.GetTouch(index);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _touchLocations.Add(new TouchLocation(touch.fingerId, touchObject));
                        break;

                    case TouchPhase.Moved:
                        TouchLocation thisTouch = GetThisTouch(touch);

                        if (ArrowTapped(_rightArrow, thisTouch))
                        {
                            Debug.LogWarning("RightArrow");
                            _horizontal = 1;
                        }
                        else if (ArrowTapped(_leftArrow, thisTouch))
                        {
                            Debug.LogError("LeftArrow");
                            _horizontal = -1;
                        }
                        else if (ArrowTapped(_upArrow, thisTouch))
                        {
                            Debug.LogError("UoArrow");
                            _vertical = 1;
                        }

                        break;

                    case TouchPhase.Ended:
                        TouchLocation touchToDelete = GetThisTouch(touch);
                        Object.Destroy(touchToDelete.Touch);
                        _touchLocations.RemoveAt(_touchLocations.IndexOf(touchToDelete));
                        break;
                }

                index++;
            }
        }
        
        private TouchLocation GetThisTouch(Touch touch)
        {
            TouchLocation thisTouch =
                _touchLocations.Find(location => location.TouchIndex == touch.fingerId);
            return thisTouch;
        }
    }
}