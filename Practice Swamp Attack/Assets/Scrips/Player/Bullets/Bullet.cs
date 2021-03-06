using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void AddExtraDamage(int damage)
    {
        _damage += damage;
    }
}
