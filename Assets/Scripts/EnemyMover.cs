using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField, Min(1)] private float _speed = 5f;

    private Vector3 _direction;

    private void Update()
    {
        Vector3 translation = _direction * _speed * Time.deltaTime;
        transform.Translate(translation);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}