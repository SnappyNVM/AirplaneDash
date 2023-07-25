using TMPro;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _percentage;

    private SceneLoader _loader;
    private int _percent;

    public bool IsLevelPassed => _percent == 100;

    private void Awake() => Initialize();

    private void Initialize()
    {
        _loader = GetComponent<SceneLoader>();
        _percent = PlayerPrefs.GetInt(_loader.SceneToLoad.ToString(), 0);
        _percentage.text = _percent.ToString() + "%";
    }
}
