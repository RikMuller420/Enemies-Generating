using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private TargetMover _target;

    public void CreateEnemy()
    {
        EnemyMover enemyMover = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        Vector3 randomDirection = new Vector3
            (
                Random.Range(-1f, 1f),
                0,
                Random.Range(-1f, 1f)
            );
        enemyMover.SetTarget(_target);
    }
}
