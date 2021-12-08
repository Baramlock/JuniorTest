using UnityEngine;

public class AttackState : State
{

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = Enemy.Delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        Target.ApplyDamage(Enemy.Damage);
        Animator.Play(EnemyAnimatorControl.States.Attack);
    }

}
