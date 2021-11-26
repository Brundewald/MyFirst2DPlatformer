using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class TouchHandler
    {
        private object _callingClass;
        private AndroidMovementHandler _androidMovementHandler;
        private PointerTrailHandler _pointerTrailHandler;
        private List<TouchLocation> _touchLocations = new List<TouchLocation>();
        private bool _isMovementHandler;

        public void TouchHandlerInit(object callingClass)
        {
            _callingClass = callingClass;
            if (_callingClass is AndroidMovementHandler androidMovementHandler)
            {
                _isMovementHandler = true;
                _androidMovementHandler = androidMovementHandler;
            }

            else if (_callingClass is PointerTrailHandler pointerTrailHandler)
            {
                _isMovementHandler = false;
                _pointerTrailHandler = pointerTrailHandler;
            }
        }
        
        public void GetTouch()
        {
            int index = 0;
            
            while (index < Input.touchCount)
            {
                Touch touch = Input.GetTouch(index);
                    
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (_isMovementHandler)
                            _touchLocations.Add(new TouchLocation(touch.fingerId, _androidMovementHandler.CreateTouchObject(touch.fingerId, touch)));
                        else
                            _touchLocations.Add(new TouchLocation(touch.fingerId, _pointerTrailHandler.CreateTrail(touch.fingerId)));
                        break;

                    case TouchPhase.Moved:
                        TouchLocation thisTouch = GetThisTouch(touch);
                        if(_isMovementHandler)
                            _androidMovementHandler.CheckTouchedButton(thisTouch);
                        else
                            _pointerTrailHandler.GetTouchPosition(thisTouch, touch);
                        break;

                    case TouchPhase.Ended:
                        TouchLocation touchToDelete = GetThisTouch(touch);
                        Object.Destroy(touchToDelete.Touch);
                        _touchLocations.RemoveAt(_touchLocations.IndexOf(touchToDelete));
                        if (_isMovementHandler)
                            _androidMovementHandler.SetToZero();
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