using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerKiller : MonoBehaviour
{
    [SerializeField] private float _afterDeathTimeModifer;

    private static PlayerKiller _instance;
    [Space] public UnityEvent PlayerDead;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<PlayerKiller>();
        }
        else
        {
            Debug.Log("PlayerKiller script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void Start()
    {
        PlayerDead.AddListener(() => Player.Instance.PlayersRB.freezeRotation = false);
        PlayerDead.AddListener(() => Player.Instance.PlayersRB.useGravity = true);
        PlayerDead.AddListener(() => Player.Instance.IsDead = true);
        PlayerDead.AddListener(() => Time.timeScale = _afterDeathTimeModifer);
    }

    public void Dead()
    {
        if (!Player.Instance.IsDead)
        {
            Destroy(Player.Instance.PlayersSpeedChanger);
            Destroy(Player.Instance.PlayersMovement);
            Destroy(Player.Instance.PlayersPropellor);
            PlayerDead?.Invoke();
        }
    }
}
