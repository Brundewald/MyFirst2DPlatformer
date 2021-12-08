using System;
using View;

namespace Controller
{
    
    public class DropScoreHandler:IInitialize
    {
        private readonly int _setZero = 0;
        private ScoreHolder _scoreHolder;
        
        public DropScoreHandler(CharacterControlView characterControl, ScoreHolder scoreHolder)
        {
            _scoreHolder = scoreHolder;
            characterControl.DropButtonInit(ResetScore);
        }

        public void ResetScore()
        {
            ResetCount();
        }

        public void Initialize()
        {
        }

        private void ResetCount()
        {
            _scoreHolder.ScoreCount = _setZero;
        }
    }
}