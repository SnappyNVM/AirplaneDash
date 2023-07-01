using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerKiller : MonoBehaviour
{
    [SerializeField] private float _afterDeathTimeModifer;

    public static PlayerKiller Instance { get; private set; }
    [Space] public UnityEvent OnPlayerDead;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<PlayerKiller>();
        }
        else
        {
            Debug.Log("PlayerKiller script has 2 realization, one of them deleted.");
            Destroy(this);
        }
    }

    private void Start()
    {
        OnPlayerDead.AddListener(() => Player.Instance.PlayersRB.freezeRotation = false);
        OnPlayerDead.AddListener(() => Player.Instance.PlayersRB.useGravity = true);
        OnPlayerDead.AddListener(() => Player.Instance.IsDead = true);
        OnPlayerDead.AddListener(() => Time.timeScale = _afterDeathTimeModifer);
    }

    public void Dead()
    {
        if (!Player.Instance.IsDead)
        {
            Destroy(Player.Instance.PlayersSpeedChanger);
            Destroy(Player.Instance.PlayersMovement);
            Destroy(Player.Instance.PlayersPropellor);
            OnPlayerDead.Invoke();
        }
    }
}
