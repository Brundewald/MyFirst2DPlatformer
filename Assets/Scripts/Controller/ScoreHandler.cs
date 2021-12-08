using System;
using TMPro;
using UnityEngine;
using View;

namespace Controller
{
    public class ScoreHandler: IExecute, IInitialize, ICleanup
    {
        private readonly CollisionHandler _collisionHandler;
        private ScoreHolder _scoreHolder;
        private TextMeshProUGUI _textMeshPro;
        private int _scoreCount;
        private string _text;

        public ScoreHandler(ScoreDisplayView scoreDisplay, CollisionHandler collisionHandler, ScoreHolder scoreHolder)
        {
            _scoreHolder = scoreHolder;
            _collisionHandler = collisionHandler;
            _textMeshPro = scoreDisplay.TextToDisplay;
        }

        public void Initialize()
        {
            _collisionHandler.OnGettingScore += ScoreUpdate;
        }

        public void Cleanup()
        {
            _collisionHandler.OnGettingScore -= ScoreUpdate;
        }

        public void Execute (float deltaTime)
        {
            DisplayScore();
        }

        private void DisplayScore()
        {
            _textMeshPro.text = $"Score: {_scoreHolder.ScoreCount}";
        }


        private void ScoreUpdate(int scoreToAdd, GameObject scoreObject)
        {
            _scoreHolder.ScoreCount += scoreToAdd;
            scoreObject.SetActive(false);
        }
    }
}
