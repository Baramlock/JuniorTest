using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UserInput))]

public class AnimationPlayer : MonoBehaviour
{
    private Animator _animation;
    private PlayerMovement _playerMove;
    private UserInput _userInput;

    private void Start()
    {
        _animation = GetComponent<Animator>();
        _playerMove = GetComponent<PlayerMovement>();
        _userInput = GetComponent<UserInput>();
    }

    private void FixedUpdate()
    {
        AnimatorControl();
    }

    private void AnimatorControl()
    {
        _animation.SetBool(AnimationPlayerControler.States.Jump, _playerMove.IsGrownded == false);
        if (_userInput.DirectionHorizontal == 1)
        {
            _animation.SetBool(AnimationPlayerControler.States.Walk, true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_userInput.DirectionHorizontal == -1)
        {
            _animation.SetBool(AnimationPlayerControler.States.Walk, true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            _animation.SetBool(AnimationPlayerControler.States.Walk, false);
        }
    }

    private class AnimationPlayerControler
    {
        public class States
        {
            public const string Walk = nameof(Walk);
            public const string Jump = nameof(Jump);
        }
    }
}
