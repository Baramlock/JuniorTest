using UnityEngine;

public class MovementByPath : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed = 5;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        if ((Vector2)transform.position == (Vector2)target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
