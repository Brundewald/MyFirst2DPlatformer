using View;

namespace Controller
{
    
    public class DropScoreHandler:IInitialize
    {
        private ScoreHandler _scoreHandler;
        
        public DropScoreHandler(ScoreHandler scoreHandler, CharacterControlView characterControl)
        {
            _scoreHandler = scoreHandler;
            characterControl.DropButtonInit(ResetScore);
        }

        public void ResetScore()
        {
            ResetCount();
        }

        private void ResetCount()
        {
            _scoreHandler.ScoreCount = 0;
        }

        public void Initialize()
        {
        }
    }
}