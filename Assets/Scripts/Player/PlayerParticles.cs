using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _onDeathParticles;

    private static PlayerParticles _instance;

    private void Start()
    {
        if (_instance == null)
        {
            _instance = GetComponent<PlayerParticles>();
            Player.Instance.PlayersKiller.PlayerDead.AddListener(SpawnDeathParticle);
        }
        else
        {
            Debug.Log("PlayersParticles script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void SpawnDeathParticle()
    {
        var particle = Instantiate(_onDeathParticles, Player.Instance.transform.position, Quaternion.identity);
        particle.gameObject.transform.SetParent(Player.Instance.transform);
    }
}
