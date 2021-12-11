using UnityEngine;

public class Axe : Weapon
{
    public override void Attack()
    {
        if (LastAttackTime < 0)
        {
            Animator.Play(PlayerAnimatorControl.States.AttackAxe);
            LastAttackTime = Delay;
            if (ShootPoint.IsCollision)
            {
                ShootPoint.IsTarget.ApplyDamage(Damage);
            }
        }
    }

    public override void PlayAnimation()
    {
        Animator.Play(PlayerAnimatorControl.States.AxeWait);
    }
}
