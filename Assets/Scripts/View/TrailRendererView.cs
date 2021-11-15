using UnityEngine;

namespace View
{
    [RequireComponent(typeof(TrailRenderer))]
    public class TrailRendererView : MonoBehaviour
    {
        [Tooltip("Drag&drop here TrailRenderer parent")] [SerializeField]
        private Transform _trailParent;

        [SerializeField] private GameObject _trailSource;
        
        public Transform TrailParent => _trailParent;
        public GameObject TrailSource => _trailSource;

    }
}