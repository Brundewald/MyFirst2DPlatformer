using UnityEngine;

namespace Controller
{
    public class TouchTrailLocation
    {
        private int _touchIndex;
        private GameObject _trailSource;

        public TouchTrailLocation(int newTouchIndex, GameObject newTrailSource)
        {
            _touchIndex = newTouchIndex;
            _trailSource = newTrailSource;
        }

        public int TouchIndex => _touchIndex;
        public GameObject TrailSource => _trailSource;
    }
}