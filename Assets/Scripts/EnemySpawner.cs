using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _spawnRate = 2f;
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints = new List<EnemySpawnPoint>();

    private void Start()
    {
        StartCoroutine(SpawnRepeating());
    }

    private IEnumerator SpawnRepeating()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnRate);

        while (enabled)
        {
            yield return wait;

            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Count);
        _spawnPoints[spawnIndex].CreateEnemy();
    }
}
