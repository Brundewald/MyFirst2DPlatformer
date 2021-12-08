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
            var animatorInitialization = new AnimatorInitialization(view.CharacterView, view.FinishView, view.EnemyView);
            var animationHandler = new AnimationHandler(animatorInitialization.CharacterAnimator(), 
                animatorInitialization.FinishAnimator(), animatorInitialization.EnemyAnimator());
            var collisionHandler = new CollisionHandler(view.CharacterView, models.ScoreHolder);
            var scoreHandler = new ScoreHandler(view.ScoreView, collisionHandler, models.ScoreHolder);
            var endGameHandler = new EndGameHandler(collisionHandler, animationHandler, models.ScoreHolder, models.LevelModel,
                view.EnemyView.gameObject, objects.LevelObject);
            var gameStateHandler = new GameStateHandler(objects.MainMenu, objects.LevelObject, endGameHandler);
            var enemyAIHandler = new EnemyAIHandler(view.CharacterView, view.EnemyView, models.ScoreHolder, models.LevelModel);
            var dropScoreHandler = new DropScoreHandler(view.CharacterControlView, models.ScoreHolder);
            var characterDeathHandler = new CharacterDeathHandler(collisionHandler, dropScoreHandler, view.CharacterView);
            var forwardDash = new ForwardDash(models.DashParameters, view.CharacterView.CharacterRigidbody2D,
                view.CharacterView.CharacterSpriteRenderer, view.CharacterControlView);
            var tweenHandler = new TweenHandler(forwardDash);
            
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
            controllers.Add(new MenuHandler(view.MainMenuView, view.CharacterControlView, gameStateHandler));
            controllers.Add(new PointerTrailHandler(view.TrailRendererView.TrailParent, view.TrailRendererView.TrailSource, objects.MainMenu));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new AndroidMovementHandler(models.CharacterModel, animationHandler, view.CharacterView, collisionHandler,
                view.CharacterControlView, objects.LevelObject, models.DashParameters));
            controllers.Add(new EnemyHandler(view.EnemyView, view.CharacterView, enemyAIHandler, models.LevelModel.EnemyBasePoint, animationHandler, objects.LevelObject));
            controllers.Add(new BonusWobblingHandler(view.BonusView, models.ScoreHolder));
        }
    }
}
