using TMPro;
using UnityEngine;

public class ScorePercentPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelPassedPercent;

    private void Start()
    {
        ScorePercentCounter.Instance.ScorePercentChanged.AddListener((int percent) =>
            _levelPassedPercent.text = percent.ToString() + "%");

        Player.Instance.PlayersKiller.PlayerDead.AddListener(() => Destroy(_levelPassedPercent.gameObject));
    }
}
