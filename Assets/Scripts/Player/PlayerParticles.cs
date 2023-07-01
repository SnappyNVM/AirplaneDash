using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerParticles : MonoBehaviour
{
    public static PlayerParticles Instance { get; private set; }
    [SerializeField] private ParticleSystem _onDeathParticles;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<PlayerParticles>();
            Player.Instance.PlayersKiller.OnPlayerDead.AddListener(SpawnDeathParticle);
        }
        else
        {
            Debug.Log("PlayersParticles script has 2 realization, one of them deleted.");
            Destroy(this);
        }
    }

    private void SpawnDeathParticle()
    {
        var particle = Instantiate(_onDeathParticles, Player.Instance.transform.position, Quaternion.identity);
        particle.gameObject.transform.SetParent(Player.Instance.transform);
    }
}
