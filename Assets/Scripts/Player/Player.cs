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

    public PlayerMovement PlayersMovement { get; private set; }
    public PlayerKiller PlayersKiller { get; private set; }
    public PlayerSpeedChanger PlayersSpeedChanger { get; private set; }
    public PlayerParticles PlayersParticles { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<Player>();
            _playersRB = GetComponent<Rigidbody>();
            PlayersMovement = GetComponent<PlayerMovement>();
            PlayersKiller = GetComponent<PlayerKiller>();
            PlayersSpeedChanger = GetComponent<PlayerSpeedChanger>();
            PlayersParticles = GetComponent<PlayerParticles>();

            IsDead = false;
        }
        else
        {
            Debug.Log("Player script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }
}
