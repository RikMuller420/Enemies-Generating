using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _spawnRate = 2f;
    [SerializeField] private EnemyMover enemyPrefab;
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

            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        int spawnIndex = Random.Range(0, _spawnPoints.Count);
        EnemyMover enemyMover = Instantiate(enemyPrefab, _spawnPoints[spawnIndex].position, Quaternion.identity);

        Vector3 randomDirection = new Vector3(
                        Random.Range(-1f, 1f),
                        0,
                        Random.Range(-1f, 1f)
                    );
        enemyMover.SetDirection(randomDirection);
    }
}
