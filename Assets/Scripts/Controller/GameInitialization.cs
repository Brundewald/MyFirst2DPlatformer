using Model;
using UnityEngine;
using View;

namespace Controller
{
    internal sealed class GameInitialization
    {        
        public GameInitialization(Controllers controllers, ViewReferenceHolder view, ObjectReferenceHolder objects, CharacterModel characterModel, GameObject scoreDisplay, LevelDataModel levelData)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var cameraController = new CameraController(camera, view.CharacterView);
            var paralaxManager = new ParalaxManager(camera, view.BackgroundView);
            var animatorInitialization = new AnimatorInitialization(view.CharacterView, view.FinishView, view.EnemyView);
            var animationHandler = new AnimationHandler(animatorInitialization.CharacterAnimator(), 
                animatorInitialization.FinishAnimator(), animatorInitialization.EnemyAnimator());
            var collisionHandler = new CollisionHandler(view.CharacterView);
            var scoreHandler = new ScoreHandler(view.ScoreView, collisionHandler);
            var endGameHandler = new EndGameHandler(collisionHandler, animationHandler, scoreHandler, levelData,
                view.EnemyView.gameObject, objects.LevelObject);
            var gameStateHandler = new GameStateHandler(objects.MainMenu, objects.LevelObject, endGameHandler);
            
            controllers.Add(cameraController);
            controllers.Add(paralaxManager);
            controllers.Add(inputInitialization);
            controllers.Add(animatorInitialization);
            controllers.Add(collisionHandler);
            controllers.Add(scoreHandler);
            controllers.Add(endGameHandler);
            controllers.Add(new MenuHandler(view.MainMenuView, view.CharacterControlView, gameStateHandler));
            controllers.Add(new PointerTrailHandler(view.TrailRendererView.TrailParent, view.TrailRendererView.TrailSource, objects.MainMenu));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new AndroidMovementHandler(characterModel, animationHandler, view.CharacterView, collisionHandler,
                view.CharacterControlView, objects.LevelObject));
            controllers.Add(new EnemyHandler(view.EnemyView, view.CharacterView, levelData.EnemyBasePoint, animationHandler, objects.LevelObject));
            
        }
    }
}
