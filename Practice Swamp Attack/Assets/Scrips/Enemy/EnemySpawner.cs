using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Player _target;
    [SerializeField] private List<Wave> _waves;

    private Wave _currentWave;
    private int _currentWaveIndex;
    private float _timeAfterLastSpawn;
    private int _spawned;

    private void Start()
    {
        SetWave(_currentWaveIndex);

    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;
        if (_timeAfterLastSpawn > _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.count <= _spawned)
        {
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        var enemy = Instantiate(_currentWave.Template, transform.position, Quaternion.identity).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.EnemyDied += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.EnemyDied -= OnEnemyDied;
        _target.AddMoney(enemy.Reward);
    }

    private void SetWave(int waveIndex)
    {
        _currentWave = _waves[waveIndex];
    }
}
[System.Serializable]
class Wave
{
    public GameObject Template;
    public float Delay;
    public int count;
}
