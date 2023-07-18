using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private float _damping;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private Vector3 _velocity = Vector3.zero;

    private void FixedUpdate() => CameraMove();

    private void CameraMove()
    {
        Vector3 moveposition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, moveposition, ref _velocity, _damping);
    }
}
