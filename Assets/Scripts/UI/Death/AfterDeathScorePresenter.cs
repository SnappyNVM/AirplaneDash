using UnityEngine;
using TMPro;

public class AfterDeathScorePresenter : MonoBehaviour
{
    [SerializeField] private GameObject _onDeadPanel;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _bestScore;

    public static AfterDeathScorePresenter Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<AfterDeathScorePresenter>();
            _onDeadPanel.SetActive(false);
            Player.Instance.PlayersKiller.OnPlayerDead.AddListener(() => InvokeRepeating(nameof(UpdateDeathPanelWhenDead), 0, 0.5f));
        }
        else
        {
            Debug.Log("AfterDeathScorePresenter script has 2 realization, one of them deleted.");
            Destroy(this);
        }
    }

    private void UpdateDeathPanelWhenDead()
    {
        if (Player.Instance.IsDead && Player.Instance.PlayersRB.velocity.magnitude == 0)
        {
            _onDeadPanel.SetActive(true);
            _currentScore.text = "Your score: " + PercentScoreCounter.Instance.CurrentScorePercent + "%";
            _bestScore.text = "Later";
            Destroy(gameObject);
        }
    }
}
