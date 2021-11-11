using TMPro;
using UnityEngine;
using View;

namespace Controller
{
    public class ScoreHandler: IExecute
    {
        private readonly CollisionHandler _collisionHandler;
        private TextMeshProUGUI _textMeshPro;
        private int _scoreCount;
        private string _text;
        
        public ScoreHandler(ScoreDisplayView scoreDisplay, CollisionHandler collisionHandler)
        {
            _collisionHandler = collisionHandler;
            _textMeshPro = scoreDisplay.GetComponent<TextMeshProUGUI>();
        }

        private void ScoreUpdate()
        {
            _scoreCount++;
            _collisionHandler.GetScore = false;
        }

        public void Execute (float deltaTime)
        {
            var getScore = _collisionHandler.GetScore;
            _textMeshPro.text = $"Score: {_scoreCount}";
            if (getScore)
            {
                ScoreUpdate();
            }
        }

        public int ScoreCount => _scoreCount;

    }
}
