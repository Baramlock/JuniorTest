using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    private Player _target;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;
        var nexState = _currentState.GetNextState();
        if (nexState != null)
        {
            Transit(nexState);
        }
    }
    private void Reset(State starteState)
    {
        _currentState = starteState;
        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;
        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}