using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.PlayersKiller.Dead();
        }
    }
}
