using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _spawnRate = 2f;
    [SerializeField, Min(1f)] private float _randomEnemyDirection = 100f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();


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

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Count - 1);
        GameObject enemy = Instantiate(enemyPrefab, _spawnPoints[spawnIndex].position, Quaternion.identity);

        if (enemy.TryGetComponent<EnemyMover>(out EnemyMover enemyMover))
        {
            Vector3 randomDirection = new Vector3(
                Random.Range(-_randomEnemyDirection, _randomEnemyDirection),
                0,
                Random.Range(-_randomEnemyDirection, _randomEnemyDirection)
            );
            enemyMover.SetDirection(randomDirection);
        }
    }
}
