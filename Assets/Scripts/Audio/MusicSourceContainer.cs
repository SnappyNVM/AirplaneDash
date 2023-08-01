using UnityEngine;

public class MusicSourceContainer : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    public AudioSource Music => _music;
    public static MusicSourceContainer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<MusicSourceContainer>();
            _music = GetComponent<AudioSource>();
        }
        else
        {
            Debug.Log("MusicSourceContainer script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }
}
