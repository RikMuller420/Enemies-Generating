using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField, Min(1)] private float _speed = 5f;

    private void Update()
    {
        Vector3 translation = transform.forward * _speed * Time.deltaTime;
        transform.Translate(translation);
    }

    public void SetDirection(Vector3 point)
    {
        transform.LookAt(point);
    }
}