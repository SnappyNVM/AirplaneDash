using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _onDeathParticles;

    public static PlayerParticles Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<PlayerParticles>();
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
