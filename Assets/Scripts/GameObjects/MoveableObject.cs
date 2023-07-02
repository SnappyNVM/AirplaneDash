using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    // Script must has parent with same position on start to work!
    [Header("Axes")]
    [SerializeField] private bool _isMoveInXAxis;
    [SerializeField] private bool _isMoveInYAxis;
    [SerializeField] private bool _isMoveInZAxis;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxDeviationDistance;

    private Vector3 _axisActiveStates;
    private bool _isMovingPositive;
    private float _currentSpeed;


    private void Start()
    {
        _axisActiveStates = new Vector3
            (_isMoveInXAxis ? 1 : 0,
            _isMoveInYAxis ? 1 : 0,
            _isMoveInZAxis ? 1 : 0);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _currentSpeed = _moveSpeed * Time.fixedDeltaTime;
        if (Mathf.Abs(transform.localPosition.x) + _currentSpeed > _maxDeviationDistance ||
            Mathf.Abs(transform.localPosition.y) + _currentSpeed > _maxDeviationDistance ||
            Mathf.Abs(transform.localPosition.z) + _currentSpeed > _maxDeviationDistance)
            _isMovingPositive = !_isMovingPositive;

        transform.Translate(_axisActiveStates * _currentSpeed * (_isMovingPositive ? 1 : -1));
    }
}
