using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "DashParameters", menuName = "DashConfig", order = 0)]
    public class DashParameters : ScriptableObject
    {
        [Header("Dash settings")] 
        [Tooltip("How fast dash is")] [SerializeField]
        private float _dashSpeed;

        [Tooltip("How far dash goes")] [SerializeField]
        private float _dashDistance;

        public float DashSpeed => _dashSpeed;
        public float DashDistance => _dashDistance;
    }
}