using UnityEngine;

namespace View
{
    public class ViewReferenceHolder: MonoBehaviour
    {
       
        
        [Header("View")][Tooltip("Drag&Drop CharacterView here")][SerializeField]
        private CharacterView _characterView;
        
        [Tooltip("Drag&Drop EnemyView here")][SerializeField]
        private EnemyView _enemyView;
    
        [Tooltip("Drag&Drop FinishView here")][SerializeField]
        private FinishView _finishView;

        [Tooltip("Drag&Drop BackgroundView here")][SerializeField]
        private BackgroundView _backgroundView;
        
        [Tooltip("Drag&Drop ScoreDisplayView here")][SerializeField]
        private ScoreDisplayView _scoreDisplayView;

        [Tooltip("Drag&Drop parent object for main menu View")] [SerializeField]
        private MainMenuView _mainMenuView;

        
        public MainMenuView MainMenuView => _mainMenuView;
        public ScoreDisplayView ScoreView => _scoreDisplayView;
        public CharacterView CharacterView => _characterView;
        public EnemyView EnemyView => _enemyView;
        public BackgroundView BackgroundView => _backgroundView;
        public FinishView FinishView => _finishView;
    }
}