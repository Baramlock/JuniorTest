using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float DirectionHorizontal { get; private set; }

    private void Update()
    {
        DirectionHorizontal = Input.GetAxisRaw("Horizontal");
    }
}