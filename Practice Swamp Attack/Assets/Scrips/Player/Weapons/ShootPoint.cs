using System.Collections;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    private bool _isCollision;
    private Enemy _target;

    public bool IsCollision => _isCollision;
    public Enemy IsTarget => _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            _isCollision = true;
            _target = enemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            _isCollision = false;
        }
    }

}
