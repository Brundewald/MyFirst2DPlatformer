using UnityEngine;
using View;

namespace Controller
{
    internal sealed class GameInitialization
    {        
        public GameInitialization(Controllers controllers, ViewReferenceHolder view, ObjectReferenceHolder objects, ModelReferenceHolder models)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var cameraController = new CameraController(camera, view.CharacterView);
            var paralaxManager = new ParalaxManager(camera, view.BackgroundView);
            var animatorInitialization = new AnimatorInitialization(view);
            var animationHandler = new AnimationHandler(animatorInitialization);
            var collisionHandler = new CollisionHandler(view.CharacterView, models.ScoreHolder);
            var scoreHandler = new ScoreHandler(view.ScoreView, collisionHandler, models.ScoreHolder);
            var endGameHandler = new EndGameHandler(collisionHandler, animationHandler, models, objects);
            var gameStateHandler = new GameStateHandler(objects);
            var enemyAIHandler = new EnemyAIHandler(view, models);
            var dropScoreHandler = new DropScoreHandler(view.CharacterControlView, models.ScoreHolder);
            var characterDeathHandler = new CharacterDeathHandler(collisionHandler, dropScoreHandler, view.CharacterView);
            var forwardDash = new ForwardDash(models.DashParameters, view);
            var tweenHandler = new TweenHandler(forwardDash);
            var rewardMenuHandler = new RewardMenuHandler(view, models, gameStateHandler);
            
            controllers.Add(cameraController);
            controllers.Add(paralaxManager);
            controllers.Add(inputInitialization);
            controllers.Add(animatorInitialization);
            controllers.Add(collisionHandler);
            controllers.Add(scoreHandler);
            controllers.Add(endGameHandler);
            controllers.Add(enemyAIHandler);
            controllers.Add(dropScoreHandler);
            controllers.Add(characterDeathHandler);
            controllers.Add(tweenHandler);
            controllers.Add(rewardMenuHandler);
            controllers.Add(new MenuHandler(view, gameStateHandler));
            controllers.Add(new PointerTrailHandler(view.TrailRendererView.TrailParent, view.TrailRendererView.TrailSource, objects.MainMenu));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new AndroidMovementHandler(models.CharacterModel, animationHandler, view.CharacterView, collisionHandler,
                view.CharacterControlView, objects.LevelObject, models.DashParameters));
            controllers.Add(new EnemyHandler(view.EnemyView, view.CharacterView, enemyAIHandler, models.LevelModel.EnemyBasePoint, animationHandler, objects.LevelObject));
            controllers.Add(new BonusWobblingHandler(view.BonusView, models.ScoreHolder));
            controllers.Add(new RewardBonusHandler(models.RewardScreenModel.RewardWindow, rewardMenuHandler));
            controllers.Add(new RewardWasRecievedMessageHandler(models.RewardScreenModel.Message, rewardMenuHandler));
        }
    }
}
