using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class PercentScoreCounter : MonoBehaviour
{
    // Put this script to finish pos for work.
    private float _zLevelDistance;
    private int _passedLevelPartPercent;

    public UnityEvent<int> OnScorePercentChanged;
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
            Debug.Log("PercentScoreCounter script has 2 realization, one of them deleted.");
            Destroy(this);
        }
    }

    private void CheckScorePercent()
    {
        int currentPercent = (int)(Player.Instance.transform.position.z / _zLevelDistance * 100);
        if (_passedLevelPartPercent < currentPercent)
        {
            CurrentScorePercent = currentPercent;
            OnScorePercentChanged.Invoke(currentPercent);
        }
        _passedLevelPartPercent = (int)(Player.Instance.transform.position.z / _zLevelDistance * 100);
    }

    private void Update()
    {
        CheckScorePercent();
    }
}
