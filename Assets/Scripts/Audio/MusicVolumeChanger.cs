using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    private Slider _musicSlider;

    private void Awake() => _musicSlider = GetComponent<Slider>();

    public void UpdateVolume() => _music.volume = _musicSlider.value; 
}
