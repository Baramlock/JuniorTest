using UnityEngine;

public class Axe : Weapon
{
    private ShootPoint _shootPoint;

    public override void Attack(Transform shootPoint)
    {
        if (_shootPoint != null)
        {
            Debug.Log("1");

            if (LastAttackTime < 0)
            {
                Animator.Play(PlayerAnimatorControl.States.AttackAxe);
                LastAttackTime = Delay;
                if (_shootPoint.IsCollision)
                {
                    _shootPoint.IsTarget.ApplyDamage(Damage);
                }
            }
        }
        else
        {
            Debug.Log("2");
            _shootPoint = shootPoint.gameObject.GetComponent<ShootPoint>();
        }
    }

    public override void PlayAnimation()
    {
        Animator.Play("Wait");
    }
}
