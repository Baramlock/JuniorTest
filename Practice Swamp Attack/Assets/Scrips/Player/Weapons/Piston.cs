using UnityEngine;

public class Piston : Weapon
{
    public override void Attack()
    {
        if (LastAttackTime < 0)
        {
            var newBullet = Instantiate(_bullet, ShootPoint.transform.position, Quaternion.identity);
            newBullet.AddExtraDamage(Damage);
            Animator.Play(PlayerAnimatorControl.States.AttackPiston);
            LastAttackTime = Delay;
        }
    }

    public override void PlayAnimation()
    {
        Animator.Play(PlayerAnimatorControl.States.Piston);
    }
}
