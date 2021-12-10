using UnityEngine;

public class Piston : Weapon
{
    public override void Attack(Transform shootPoint)
    {
        const string attackPiston = PlayerAnimatorControl.States.AttackPiston;
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(attackPiston) == false)
        {

            var newBullet = Instantiate(_bullet, shootPoint.position, Quaternion.identity);
            newBullet.AddExtraDamage(Damage);
            Animator.Play(attackPiston);
        }
    }

    public override void PlayAnimation()
    {
        Animator.Play(PlayerAnimatorControl.States.Piston);
    }
}
