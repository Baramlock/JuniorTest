using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float DirectionHorizontal { get; private set; }
    public float DirectionVertical { get; private set; }


    void Update()
    {
        DirectionHorizontal = Input.GetAxisRaw("Horizontal");
        DirectionVertical = Input.GetAxisRaw("Vertical");
    }
}
