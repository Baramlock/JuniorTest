using UnityEngine;

public class MoveState : State
{
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Enemy.Speed);
        if (transform.position.x - Target.transform.position.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnEnable()
    {
        Animator.Play(EnemyAnimatorControl.States.Move);
    }

    private void OnDisable()
    {
        Animator.StopPlayback();
    }
}
