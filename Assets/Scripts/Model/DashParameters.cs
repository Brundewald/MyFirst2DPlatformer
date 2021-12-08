using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "DashParameters", menuName = "Data/DashConfig", order = 0)]
    public class DashParameters : ScriptableObject
    {
        [Header("Dash settings")] 
        [Tooltip("How fast dash is")] [SerializeField]
        private float _dashDuration;

        [Tooltip("How far dash goes")] [SerializeField]
        private float _dashDistance;

        public float DashDuration => _dashDuration;
        public float DashDistance => _dashDistance;
    }
}