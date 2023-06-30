using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            Player.Instance.PlayersKiller.Dead();
        }
    }
}
