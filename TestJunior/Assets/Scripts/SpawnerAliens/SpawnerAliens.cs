using System.Collections;
using UnityEngine;

public class SpawnerAliens : MonoBehaviour
{
    [SerializeField] private GameObject _aliens;
    [SerializeField] private Transform _point;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(2);
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        for (int i = 0; i < _point.childCount; i++)
        {
            yield return _waitForSeconds;
            GameObject newAliens = Instantiate(_aliens, _point.GetChild(i).transform.position, Quaternion.identity);
        }
    }

}



