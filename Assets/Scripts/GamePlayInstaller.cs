using Colliders;
using Counters;
using Hole;
using Input;
using Movement;
using UnityEngine;
using Zenject;

public class GamePlayInstaller : MonoInstaller
{
    [SerializeField] private ObjectTouchSystem objectTouchSystem;
    [SerializeField] private Rigidbody hole;
    [SerializeField] private HoleCollidersContainer _holeColliders;

    private HoleMovement _holeMovement;
    private Counter _counter;
    private HoleScaleHandler _scaleHandler;
    
    public override void InstallBindings()
    {
        _counter = new Counter();
        _scaleHandler = new HoleScaleHandler(2f, 3, hole.transform);
        _holeMovement = new HoleMovement(objectTouchSystem, hole);

        _counter.OnCounterValueChanged += _scaleHandler.ScaleUp;
        objectTouchSystem.OnDrag += _holeMovement.Move;

        Container.Bind<ICounter>().FromInstance(_counter);
        Container.Bind<HoleCollidersContainer>().FromInstance(_holeColliders);
    }
}