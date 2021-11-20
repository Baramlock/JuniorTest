using UnityEngine;

[RequireComponent(typeof(UserInput))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _strenghtHorizontal = 500;
    [SerializeField] private float _strenghtVertical = 200;

    private UserInput _userInput;
    private Rigidbody2D _rigidbody2D;

    public bool IsGrownded { get; private set; }

    private void Start()
    {
        _userInput = GetComponent<UserInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.AddForce(Vector2.right * Time.deltaTime * _strenghtHorizontal * _userInput.DirectionHorizontal);
        if (IsGrownded && _userInput.DirectionVertical == 1)
        {
            IsGrownded = false;
            _rigidbody2D.AddForce(Vector2.up * _strenghtVertical * _userInput.DirectionVertical);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrownded = true;
    }
}
