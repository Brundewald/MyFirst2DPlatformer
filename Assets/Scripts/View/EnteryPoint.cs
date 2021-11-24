using Controller;
using Model;
using View;
using UnityEngine;

public sealed class EnteryPoint : MonoBehaviour
{
    [SerializeField] private ViewReferenceHolder _view;
    [SerializeField] private ObjectReferenceHolder _objectsReference;
    [SerializeField] private ModelReferenceHolder _modelReference;

    private Controllers _controllers;

    private void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _view, _objectsReference, _modelReference);
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
