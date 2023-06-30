using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Rigidbody PlayersRB => _playersRB;
    private Rigidbody _playersRB;

    public RotaterByCenter PlayersPropellor => _playersPropellor;
    [SerializeField] private RotaterByCenter _playersPropellor;

    public PlayerMovement PlayersMovement => PlayerMovement.Instance;
    public PlayerKiller PlayersKiller => PlayerKiller.Instance;
    public PlayerSpeedChanger PlayersSpeedChanger => PlayerSpeedChanger.Instance;
    public PlayerParticles PlayersParticles => PlayerParticles.Instance;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<Player>();
            _playersRB = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.Log("Player script has 2 realization, one of them deleted.");
            Destroy(this);
        }
    }

    private void Start()
    {
        PlayersKiller.OnDeath.AddListener(() => PlayersRB.freezeRotation = false);
        PlayersKiller.OnDeath.AddListener(() => PlayersRB.useGravity = true);
    }
}
