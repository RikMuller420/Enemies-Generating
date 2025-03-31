using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _speed = 5f;
    [SerializeField] private List<Transform> _patrolPoints = new List<Transform>();

    private int _targetPatrolIndex = 1;

    private void Awake()
    {
        if (_patrolPoints.Count < 2)
        {
            gameObject.SetActive(false);

            return;
        }

        transform.position = _patrolPoints[0].position;
    }

    private void Update()
    {
        float stepDistance = _speed * Time.deltaTime;
        Vector3 targetPosition = _patrolPoints[_targetPatrolIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, stepDistance);

        if (transform.position == targetPosition)
        {
            SetNextPatrolPoint();
        }
    }

    private void SetNextPatrolPoint()
    {
        _targetPatrolIndex++;

        if (_targetPatrolIndex == _patrolPoints.Count)
        {
            _targetPatrolIndex = 0;
        }
    }
}
