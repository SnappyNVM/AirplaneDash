using UnityEngine;
using UnityEngine.Timeline;

public class SoundEffectsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _main;
    [SerializeField] private AudioClip _explosion;


    public static SoundEffectsPlayer Instance { get; private set; } 

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<SoundEffectsPlayer>();
            Player.Instance.PlayersKiller.PlayerDead.AddListener(PlayExplosionSound);
        }
        else
        {
            Debug.Log("SoundEffectsPlayer script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    public void PlayExplosionSound() => _main.PlayOneShot(_explosion);
}
