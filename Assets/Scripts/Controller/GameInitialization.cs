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
            
            controllers.Add(cameraController);
            controllers.Add(paralaxManager);
            controllers.Add(inputInitialization);
            controllers.Add(animatorInitialization);
            controllers.Add(collisionHandler);
            controllers.Add(scoreHandler);
            controllers.Add(new MenuHandler(view.MainMenuView));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MovementHandler(inputInitialization.GetInput(), characterModel, animationHandler, view.CharacterView, collisionHandler));
            controllers.Add(new EnemyHandler(view.EnemyView, view.CharacterView, levelData.EnemyBasePoint, animationHandler));
            controllers.Add(new EndGameHandler(collisionHandler, animationHandler, scoreHandler, levelData, view.EnemyView.gameObject));
        }
    }
}
