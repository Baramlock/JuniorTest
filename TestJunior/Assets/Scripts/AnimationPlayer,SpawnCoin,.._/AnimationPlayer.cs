using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UserInput))]

public class AnimationPlayer : MonoBehaviour
{
    private Animator _animation;
    private PlayerMove _playerMove;
    private UserInput _userInput;

    private void Start()
    {
        _animation = GetComponent<Animator>();
        _playerMove = GetComponent<PlayerMove>();
        _userInput = GetComponent<UserInput>();
    }

    private void FixedUpdate()
    {
        if (_playerMove.IsGrownded == false)
            SetBoolJump(true);
        else
            SetBoolJump(false);

        AnimatorControl();
    }

    private void AnimatorControl()
    {
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

    private void SetBoolJump(bool isJump)
    {
        _animation.SetBool(AnimationPlayerControler.States.Jump, true);
    }

    public class AnimationPlayerControler
    {
        public class States
        {
            public const string Walk = nameof(Walk);
            public const string Jump = nameof(Jump);
        }
    }
}
