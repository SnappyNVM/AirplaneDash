using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    private Slider _musicSlider;

    private void Start()
    {
        _musicSlider = GetComponent<Slider>();
        _music = MusicSourceContainer.Instance.Music;
        _musicSlider.value = _music.volume;
    }

    public void UpdateVolume() => _music.volume = _musicSlider.value; 
}
