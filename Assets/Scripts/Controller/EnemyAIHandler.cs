using View;

namespace Controller
{
    public class EnemyAIHandler:IInitialize
    {
        private readonly ScoreHolder _scoreHolder;
        private readonly CharacterView _characterView;
        private readonly EnemyView _enemyView;
        private readonly int _awarenessScore;

        private float _reactionDistance;

        public EnemyAIHandler(ViewReferenceHolder view, ModelReferenceHolder models)
        {
            _scoreHolder = models.ScoreHolder;
            _characterView = view.CharacterView;
            _enemyView = view.EnemyView;

            _awarenessScore = models.LevelModel.AwarenessScore;
            _reactionDistance = view.EnemyView.ReactionDistance;
        }

        public void Initialize(){}

        public bool IsCharacterStoleApple()
        {
            bool isAppleStolen;
            var playerScore = _scoreHolder.ScoreCount;
            if (IsCharacterClose())
            {
                if (playerScore >= _awarenessScore)
                    isAppleStolen = true;
                else
                    isAppleStolen = false;
            }
            else
            {
                isAppleStolen = false;
            }
            
            return isAppleStolen;
        }

        private bool IsCharacterClose()
        {
            var distance = (_characterView.transform.position - _enemyView.transform.position).magnitude;
            
            var characterClose = distance < _reactionDistance;

            return characterClose;
        }
    }
}