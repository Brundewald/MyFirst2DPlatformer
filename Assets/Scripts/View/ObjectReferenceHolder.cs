using UnityEngine;

namespace View
{
    public class ObjectReferenceHolder : MonoBehaviour
    {
        [Header("Objects")][Tooltip("Drag&Drop here the parent object which contain all game objects")][SerializeField]
        private GameObject _objectsOnScene;

        [Tooltip("Drag&Drop parent object for main menu")] [SerializeField]
        private GameObject _mainMenuObject;
        
        [Tooltip("Drag&Drop parent object for Reward menu")] [SerializeField]
        private GameObject _rewardMenyObject;
        
        
        public GameObject LevelObject => _objectsOnScene;
        public GameObject MainMenu => _mainMenuObject;
        public GameObject RewardMenu => _rewardMenyObject;
    }
}