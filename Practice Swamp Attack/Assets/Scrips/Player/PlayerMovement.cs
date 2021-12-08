using UnityEngine;

[RequireComponent(typeof(UserInput))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    private UserInput _userInput;

    private void Start()
    {
        _userInput = GetComponent<UserInput>();
    }

    private void Update()
    {
        if (_userInput.DirectionHorizontal == 1)
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_userInput.DirectionHorizontal == -1)
        {
            transform.position += Vector3.left * Time.deltaTime * _speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
    }
}