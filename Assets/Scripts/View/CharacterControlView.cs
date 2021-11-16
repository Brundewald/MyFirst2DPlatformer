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

        public void Init(UnityAction moveLeft, UnityAction moveRight, UnityAction jump)
        {
            _leftArrow.onClick.AddListener(moveLeft);
            //_rightArrow.onClick.AddListener(moveRight);
            _upArrow.onClick.AddListener(jump);
        }

        public void PauseInit(UnityAction pause)
        {
            _pauseButton.onClick.AddListener(pause);
        }

        public void OnDestroy()
        {
            _leftArrow.onClick.RemoveAllListeners();
            _rightArrow.onClick.RemoveAllListeners();
            _upArrow.onClick.RemoveAllListeners();
        }

        public Button RightArrow => _rightArrow;

    }
}