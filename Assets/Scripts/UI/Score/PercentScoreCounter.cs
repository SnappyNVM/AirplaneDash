using UnityEngine;
using UnityEngine.Events;

public class PercentScoreCounter : MonoBehaviour
{
    // Put this script into finish pos for work.
    private float _zLevelDistance;
    private int _passedLevelPartPercent;

    public UnityEvent<int> ScorePercentChanged;
    public static PercentScoreCounter Instance { get; private set; }
    public int CurrentScorePercent { get; set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<PercentScoreCounter>();
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
        int currentPercent = (int)(Player.Instance.transform.position.z / _zLevelDistance * 100);
        if (_passedLevelPartPercent < currentPercent)
        {
            CurrentScorePercent = currentPercent;
            ScorePercentChanged?.Invoke(currentPercent);
        }
        _passedLevelPartPercent = (int)(Player.Instance.transform.position.z / _zLevelDistance * 100);
    }

    private void Update()
    {
        CheckScorePercent();
    }
}
