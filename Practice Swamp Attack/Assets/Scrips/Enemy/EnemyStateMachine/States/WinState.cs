    public class WinState : State
    {
        private void OnEnable()
        {
            Animator.Play(EnemyAnimatorControl.States.Victory);
        }
        private void OnDisable()
        {
            Animator.StopPlayback();
        }
    }