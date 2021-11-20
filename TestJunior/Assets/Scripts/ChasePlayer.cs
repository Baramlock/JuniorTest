using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 _vector3 = new Vector3(0, 0, 10);
    private void FixedUpdate()
    {
        transform.position = _player.transform.position - _vector3;
    }
}
