using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void FixedUpdate()
    {
        transform.position = _player.transform.position - Vector3.forward;
    }
}
