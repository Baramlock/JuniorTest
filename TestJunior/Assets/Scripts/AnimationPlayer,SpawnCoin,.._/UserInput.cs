using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float DirectionHorizontal { get; private set; }
    public float DirectionVertical { get; private set; }

    private void Update()
    {
        DirectionHorizontal = Input.GetAxisRaw("Horizontal");
        DirectionVertical = Input.GetAxisRaw("Vertical");
    }
}
