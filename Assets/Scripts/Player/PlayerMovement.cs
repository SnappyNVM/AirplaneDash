using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _horizontalMovementSpeed;
    [SerializeField] private float _verticalMovementSpeed;

    private float _forwardMovementSpeed;

    private static PlayerMovement _instance;

    public float ForwardMovementSpeed { get => _forwardMovementSpeed; set { _forwardMovementSpeed = value; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<PlayerMovement>();
        }
        else
        {
            Debug.Log("PlayerMovement script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void Move()
    {
        Player.Instance.PlayersRB.velocity = 
        new Vector3(_horizontalMovementSpeed * _joystick.Horizontal, _verticalMovementSpeed * _joystick.Vertical, _forwardMovementSpeed) * Time.fixedDeltaTime;

        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(_joystick.Vertical)) * Mathf.Sign(_joystick.Vertical);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(_joystick.Horizontal)) * -Mathf.Sign(_joystick.Horizontal);

        transform.localRotation = Quaternion.Euler(Vector3.forward * roll + Vector3.right * pitch);
    }

    private void FixedUpdate() => Move();

    private void OnDestroy()
    {
        if (_joystick != null)
            Destroy(_joystick.gameObject);
    }
}
