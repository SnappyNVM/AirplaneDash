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
        PlayerDead.AddListener(() => Player.Instance.PlayersFallingDoer.MakeThePlayerFall());
        PlayerDead.AddListener(() => Player.Instance.IsDead = true);
        PlayerDead.AddListener(() => Time.timeScale = _afterDeathTimeModifer);
    }

    public void Dead()
    {
        if (!Player.Instance.IsDead && !Player.Instance.PlayersFinishEnterer.IsFinished)
        {
            PlayerDead?.Invoke();
        }
    }
}
