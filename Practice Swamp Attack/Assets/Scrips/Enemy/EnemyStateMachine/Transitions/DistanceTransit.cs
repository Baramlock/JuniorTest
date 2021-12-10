using UnityEngine;

public class DistanceTransit : Transition
{
    [SerializeField] private float _rangeTransit;
    [SerializeField] private float _spread;
    [SerializeField] private bool _isLess;

    private void Start()
    {
        _rangeTransit -= Random.Range(-_spread, _spread);
    }

    private void Update()
    {
        if (Target == null) 
            return;

        if ((Vector2.Distance(transform.position, Target.transform.position) < _rangeTransit) == _isLess)
        {
            NeedTransit = true;
        }
    }
}