using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private int _speed;
    [SerializeField] private int _reward;
    private Player _target;

    public int Reward => _reward;
    public int Damage => _damage;
    public int Speed => _speed;
    public Player Target => _target;
    public float Delay => _delay;

    public UnityAction<Enemy> EnemyDied;

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            EnemyDied?.Invoke(this);
            Destroy(gameObject);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
