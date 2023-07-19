using UnityEngine;
using UnityEngine.Timeline;

public class SoundEffectsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _main;
    [SerializeField] private AudioClip _explosion;
    [SerializeField] private AudioClip _finish;


    public static SoundEffectsPlayer Instance { get; private set; } 

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<SoundEffectsPlayer>();
            Player.Instance.PlayersFinishEnterer.PlayerFinished.AddListener(() => _main.PlayOneShot(_finish));
        }
        else
        {
            Debug.Log("SoundEffectsPlayer script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    public void PlayExplosionSound() => _main.PlayOneShot(_explosion);
}
