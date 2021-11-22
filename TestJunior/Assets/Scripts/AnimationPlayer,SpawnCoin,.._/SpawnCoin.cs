using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Coin _coin;

    private void Start()
    {
        for (int i = 0; i < _path.childCount; i++)
        {
            Instantiate(_coin, _path.GetChild(i).transform.position, Quaternion.identity);
        }
    }
}
