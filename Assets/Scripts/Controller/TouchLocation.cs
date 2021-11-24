using UnityEngine;

namespace Controller
{
    public class TouchLocation
    {
        private int _touchIndex;
        private GameObject _touch;
    
        public TouchLocation(int newTouchIndex, GameObject newTouch)
        {
            _touchIndex = newTouchIndex;
            _touch = newTouch;
        }

        public int TouchIndex => _touchIndex;
        public GameObject Touch => _touch;
    }
}