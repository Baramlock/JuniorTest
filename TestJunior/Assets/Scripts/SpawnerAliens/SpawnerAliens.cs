using System.Collections;
using UnityEngine;

public class SpawnerAliens : MonoBehaviour
{
    [SerializeField] private GameObject _alien;
    [SerializeField] private Transform _point;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(2);
        StartCoroutine(SpawnAliens());
    }

    private IEnumerator SpawnAliens()
    {
        for (int i = 0; i < _point.childCount; i++)
        {
            yield return _waitForSeconds;
            GameObject newAliens = Instantiate(_alien, _point.GetChild(i).transform.position, Quaternion.identity);
        }
    }
}



