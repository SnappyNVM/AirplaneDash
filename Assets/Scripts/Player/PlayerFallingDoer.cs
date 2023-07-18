using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerFallingDoer : MonoBehaviour
{
    private static PlayerFallingDoer _instance;

    private void Start()
    {
        if (_instance == null)
        {
            _instance = GetComponent<PlayerFallingDoer>();
        }
        else
        {
            Debug.Log("PlayerFallingDoer script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    public void MakeThePlayerFall()
    {
        Player player = Player.Instance;
        Destroy(player.PlayersPropellor);
        Destroy(player.PlayersSpeedChanger);
        Destroy(player.PlayersMovement);

        player.PlayersRB.freezeRotation = false;
        player.PlayersRB.useGravity = true;
        player.PlayersRB.angularDrag = 0.4f;
        player.PlayersRB.drag = 0.4f;
    }
}
