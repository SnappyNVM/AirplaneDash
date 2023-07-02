using UnityEngine;
using UnityEngine.Events;

public class ScorePercentCounter : MonoBehaviour
{
    // Put this script into finish pos for work.
    private float _zLevelDistance;
    private int _passedLevelPartPercent;
    private int _currentFreeScorePercent;
    private int _currentFixedScorePercent;

    public UnityEvent<int> ScorePercentChanged;
    public static ScorePercentCounter Instance { get; private set; }

    public int CurrentScorePercent
    {
        get => _currentFixedScorePercent;
        set => _currentFixedScorePercent = Mathf.Clamp(value, 0, 100);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<ScorePercentCounter>();
            _zLevelDistance = GetComponent<Transform>().position.z;
        }
        else
        {
            Debug.Log("PercentScoreCounter script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void CheckScorePercent()
    {
        _currentFreeScorePercent = (int)(Player.Instance.transform.position.z / _zLevelDistance * 100);
        if (_passedLevelPartPercent < _currentFreeScorePercent)
        {
            CurrentScorePercent = _currentFreeScorePercent;
            ScorePercentChanged?.Invoke(CurrentScorePercent);
        }
        _passedLevelPartPercent = (int)(Player.Instance.transform.position.z / _zLevelDistance * 100);
    }

    private void Update()
    {
        CheckScorePercent();
    }
}
