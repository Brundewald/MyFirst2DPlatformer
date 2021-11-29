using View;

namespace Controller
{
    public class EnemyAIHandler:IInitialize
    {
        private readonly CharacterView _characterView;
        private readonly ScoreHandler _scoreHandler;
        private readonly EnemyView _enemyView;
        private readonly int _awarenessScore;

        private float _reactionDistance;

        public EnemyAIHandler(CharacterView characterView, EnemyView enemyView, ScoreHandler scoreHandler, LevelDataModel levelDataModel)
        {
            _characterView = characterView;
            _enemyView = enemyView;
            _scoreHandler = scoreHandler;

            _awarenessScore = levelDataModel.AwarenessScore;
            _reactionDistance = enemyView.ReactionDistance;
        }

        public void Initialize(){}

        public bool IsCharacterStoleApple()
        {
            bool isAppleStolen;
            if (IsCharacterClose())
            {
                if (_scoreHandler.ScoreCount >= _awarenessScore)
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