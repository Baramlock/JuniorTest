using UnityEngine;

    public class Piston : Weapon
    {
        public override void Attack()
        {
            const string attackPiston = PlayerAnimatorControl.Triggers.AttackPiston;
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName(attackPiston) ==false)
            {
                Instantiate(_bullet, transform.position, Quaternion.identity);
                _animator.SetTrigger(attackPiston);
            }
        }
    }
