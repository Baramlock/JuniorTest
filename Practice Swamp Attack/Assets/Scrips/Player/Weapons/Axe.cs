using System.Collections;
using UnityEngine;

public class Axe : Weapon
{
    private bool _isCollision;
    private Enemy _target;

    private void Update()
    {
        LastAttackTime -= Time.deltaTime;
    }

    public override void Attack()
    {
        if (LastAttackTime < 0)
        {
            _animator.Play(PlayerAnimatorControl.Triggers.AttackAxe);
            LastAttackTime = Delay;
            if (_isCollision)
            {
                _target.ApplyDamage(Damage);
            }
        }
    }

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
