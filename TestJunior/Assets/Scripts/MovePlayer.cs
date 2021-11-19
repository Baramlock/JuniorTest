using UnityEngine;

[RequireComponent(typeof(UserInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _strenghtHorizontal = 500;
    [SerializeField] private float _strenghtVertical = 200;

    private UserInput _userInput;
    private Rigidbody2D _rigidbody2D;

    private bool isGrownded;

    private void Start()
    {
        _userInput = GetComponent<UserInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.AddForce(Vector2.right * Time.deltaTime * _strenghtHorizontal * _userInput.DirectionHorizontal);
        if (isGrownded && _userInput.DirectionVertical == 1)
        {
            isGrownded = false;
            _rigidbody2D.AddForce(Vector2.up * _strenghtVertical * _userInput.DirectionVertical);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrownded = true;
    }
}
