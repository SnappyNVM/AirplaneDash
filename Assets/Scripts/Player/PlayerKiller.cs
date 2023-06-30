using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerKiller : MonoBehaviour
{
    public static PlayerKiller Instance { get; private set; }
    public UnityEvent OnDeath;

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

    public void Dead()
    {
        Destroy(Player.Instance.PlayersSpeedChanger);
        Destroy(Player.Instance.PlayersMovement);
        Destroy(Player.Instance.PlayersPropellor);
        OnDeath.Invoke();
    }
}
