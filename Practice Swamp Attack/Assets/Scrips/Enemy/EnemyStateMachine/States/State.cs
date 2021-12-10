using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    protected Animator Animator { get; private set; }
    protected Player Target;
    protected Enemy Enemy;

    public void Enter(Player target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(target);
            }
        }
    }

    public void Exit()
    {
        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }
        enabled = false;
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }
        return null;
    }

    private void Awake()
    {
        Enemy = GetComponent<Enemy>();
        Animator = GetComponent<Animator>();
    }
}