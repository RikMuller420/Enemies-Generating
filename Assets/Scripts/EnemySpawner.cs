using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _spawnRate = 2f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
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
    }
}
