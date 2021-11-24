using UnityEngine;

namespace View
{
    public class ObjectReferenceHolder : MonoBehaviour
    {
        [Header("Objects")][Tooltip("Drag&Drop here the parent object wich containt all game objects")][SerializeField]
        private GameObject _objectsOnScene;

        [Tooltip("Drag&Drop parent object for main menu")] [SerializeField]
        private GameObject _mainMenuObject;
        
        [Tooltip("Drag&Drop parent object for main menu")] [SerializeField]
        private GameObject _pauseMenyObject;
        
        
        public GameObject LevelObject => _objectsOnScene;
        public GameObject MainMenu => _mainMenuObject;
        public GameObject PauseMenu => _pauseMenyObject;
    }
}