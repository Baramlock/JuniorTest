using System.Collections;
using UnityEngine;

public class SpawnerAliens : MonoBehaviour
{
    [SerializeField] private Alien _alien;
    [SerializeField] private Transform _point;


    private void Start()
    {
        StartCoroutine(SpawnAliens());
    }

    private IEnumerator SpawnAliens()
    {
        var waitForSeconds = new WaitForSeconds(2);
        for (int i = 0; i < _point.childCount; i++)
        {
            yield return waitForSeconds;
            var newAliens = Instantiate(_alien, _point.GetChild(i).transform.position, Quaternion.identity);
        }
    }
}



