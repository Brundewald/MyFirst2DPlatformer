using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace View
{
    public class CharacterControlView : MonoBehaviour
    {
        [Tooltip("Drag&drop here Left Arrow button")] [SerializeField]
        private Button _leftArrow;
        [Tooltip("Drag&drop here Right Arrow button")] [SerializeField]
        private Button _rightArrow;
        [Tooltip("Drag&drop here Up Arrow button")] [SerializeField]
        private Button _upArrow;
        [Tooltip("Drag&drop here Pause button")] [SerializeField]
        private Button _pauseButton;
        [Tooltip("Drag&drop here Dash button")] [SerializeField]
        private Button _dashButton;

        public void Init(UnityAction pause, UnityAction forwardDash)
        {
            _pauseButton.onClick.AddListener(pause);
            _dashButton.onClick.AddListener(forwardDash);
        }

        public void OnDestroy()
        {
            _pauseButton.onClick.RemoveAllListeners();
            _dashButton.onClick.RemoveAllListeners();
        }

        public Button RightArrow => _rightArrow;
        public Button LeftArrow => _leftArrow;
        public Button UpArrow => _upArrow;
    }
}