using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _rotationSpeed = 100.0f;

    private int _currentWaypoint = 0;

    private void Update()
    {
        RotateSmoothly();
        MoveWaypoint();
        NextWaypoint();
    }

    private void RotateSmoothly()
    {
        Vector3 direction = _waypoints[_currentWaypoint].transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void MoveWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    private void NextWaypoint()
    {
        if (transform.position == _waypoints[_currentWaypoint].transform.position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }
    }
}