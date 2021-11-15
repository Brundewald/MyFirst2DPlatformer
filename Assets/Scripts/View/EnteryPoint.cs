using Controller;
using Model;
using View;
using UnityEngine;

public sealed class EnteryPoint : MonoBehaviour
{
    [SerializeField] private ViewReferenceHolder _view;
    [SerializeField] private ObjectReferenceHolder _objectsReference;
    [SerializeField] private CharacterModel _characterModel;
    [SerializeField] private LevelDataModel _levelData;
    [SerializeField] private GameObject _scoreDisplay;

    private Controllers _controllers;
    private bool _isExitPressed;


    private void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _view, _objectsReference, _characterModel, _scoreDisplay, _levelData);
        _controllers.Initialize();
    }

   
    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _controllers.Execute(deltaTime);       
    }

    private void FixedUpdate()
    {
        var deltaTime = Time.fixedDeltaTime;
        _controllers.LateExecute(deltaTime);
    }

    private void OnDestroy()
    {
        _controllers.Cleanup();
    }
}
