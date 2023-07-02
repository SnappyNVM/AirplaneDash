using System.Diagnostics.Contracts;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Rigidbody PlayersRB => _playersRB;
    private Rigidbody _playersRB;

    public RotaterByCenter PlayersPropellor => _playersPropellor;
    [SerializeField] private RotaterByCenter _playersPropellor;

    public bool IsDead { get; set; }

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
            IsDead = false;
        }
        else
        {
            Debug.Log("Player script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }
}
