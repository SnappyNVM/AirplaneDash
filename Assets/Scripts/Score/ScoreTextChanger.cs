using TMPro;
using UnityEngine;

public class ScoreTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelPassedPercent;

    private void Start()
    {
        PercentScoreCounter.Instance.OnScorePercentChanged.AddListener(UpdateText);
    }

    private void UpdateText(int percent)
    {
        _levelPassedPercent.text = percent.ToString() + "%"; 
    }
}
