using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField, Min(1)] private float _speed = 5f;

    private TargetMover _target;

    private void Update()
    {
        float stepDistance = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards
            (
                transform.position,
                _target.transform.position,
                stepDistance
            );
    }

    public void SetTarget(TargetMover target)
    {
        _target = target;
    }
}