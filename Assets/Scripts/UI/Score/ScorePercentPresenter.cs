using TMPro;
using UnityEngine;

public class ScorePercentPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelPassedPercent;

    private void Start() =>
        PercentScoreCounter.Instance.ScorePercentChanged.AddListener((int percent) => 
            _levelPassedPercent.text = percent.ToString() + "%");
}
