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
        SetBoolJump();
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
    private void SetBoolJump()
    {
        if (_playerMove.IsGrownded == false)
        {
            _animation.SetBool(AnimationPlayerControler.States.Jump, true);
        }
        else
        {
            _animation.SetBool(AnimationPlayerControler.States.Jump, false);
        }
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
